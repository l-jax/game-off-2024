using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public IGameState CurrentGameState { get; private set; }
    public IPuzzle CurrentPuzzle { get; private set; }

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
        _puzzleActiveState = new PuzzleActiveState(this, GetComponentInChildren<TimeDisplay>());
        _puzzleCompleteState = new PuzzleCompleteState(this);

        _puzzles = new Stack<IPuzzle>(GetComponentsInChildren<IPuzzle>().Reverse());

        Initialise();
    }

    public void Update() 
    {
        CurrentGameState.Update();
    }

    internal void StartGame() 
    {
        if (CurrentGameState != _startState) {
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
        if (_puzzles.Count == 0) {
            TransitionTo(_endState);
        } 
        else {
            CurrentPuzzle = _puzzles.Pop();
            TransitionTo(_puzzleActiveState);
        }
    }

    internal void TimeUp()
    {
        CurrentGameState = _loseState;
        Debug.Log("Time has run out");
    }

    private void Initialise()
    {
        CurrentGameState = _startState;
        CurrentPuzzle = _puzzles.Pop();
        _startState.Enter();
        Debug.Log("Game Initialised");
    }

    private void TransitionTo(IGameState nextState)
    {
        Debug.Log($"Updating game state from { CurrentGameState } to { nextState }");
        CurrentGameState = nextState;
        nextState.Enter();
    }
}
