using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnGameEnd;

    public IPuzzle CurrentPuzzle { get; private set; }
    public bool PuzzleActive { get => _currentGameState == _puzzleActiveState; }

    [SerializeField]
    private float _secondsBetweenPuzzles = 1f;

    private IGameState _currentGameState;
    private Stack<IPuzzle> _puzzles;
    private StartState _startState;
    private PuzzleActiveState _puzzleActiveState;
    private PuzzleCompleteState _puzzleCompleteState;
    private EndState _endState;
    private LoseState _loseState;

    public void Awake()
    {
        Instance = this;

        _startState = new StartState(this);
        _endState = new EndState(this);
        _loseState = new LoseState(this);
        _puzzleActiveState = new PuzzleActiveState(this, GetComponent<TimeDisplay>());
        _puzzleCompleteState = new PuzzleCompleteState(this);

        _puzzles = new Stack<IPuzzle>(GetComponentsInChildren<IPuzzle>().Reverse());

        Initialise();
    }

    public void Update() 
    {
        _currentGameState.Update();
    }

    internal void StartGame() 
    {
        if (_currentGameState != _startState) {
            throw new InvalidOperationException("Game has already started");
        }

        TransitionTo(_puzzleActiveState);
    }

    internal void CompletePuzzle(IPuzzle puzzle)
    {
        if (CurrentPuzzle != puzzle) {
            throw new InvalidOperationException($"Cannot complete {puzzle.Name} because it is not the curren puzzle { CurrentPuzzle.Name}");
        }

        TransitionTo(_puzzleCompleteState);
    }

    internal void NextPuzzleOrEndGame()
    {
        StartCoroutine(WaitThenNext());
    }

    internal void EndGame()
    {
        OnGameEnd?.Invoke();
    }

    internal void TimeUp()
    {
        TransitionTo(_loseState);
        Debug.Log("Time has run out");
    }

    private void Initialise()
    {
        _currentGameState = _startState;
        CurrentPuzzle = _puzzles.Pop();
        _startState.Enter();
        Debug.Log("Game Initialised");
    }

    private void TransitionTo(IGameState nextState)
    {
        Debug.Log($"Updating game state from { _currentGameState } to { nextState }");
        _currentGameState = nextState;
        nextState.Enter();
    }

    private IEnumerator WaitThenNext() {
        yield return new WaitForSeconds(_secondsBetweenPuzzles);

        if (_puzzles.Count == 0) {
            TransitionTo(_endState);
        } 
        else {
            CurrentPuzzle = _puzzles.Pop();
            TransitionTo(_puzzleActiveState);
        }
    }
}
