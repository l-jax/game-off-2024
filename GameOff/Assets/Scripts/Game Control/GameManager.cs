using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public IGameState CurrentGameState { get; private set; }
    public IPuzzle CurrentPuzzle { get; private set; }

    private StartState _startState;
    private PuzzleActiveState _puzzleActiveState;
    private PuzzleCompleteState _puzzleCompleteState;
    private EndState _endState;

    public void Awake()
    {
        Instance = this;
        CurrentPuzzle = GetComponentInChildren<IPuzzle>();

        _startState = new StartState(this);
        _endState = new EndState(this);
        _puzzleActiveState = new PuzzleActiveState(this);
        _puzzleCompleteState = new PuzzleCompleteState(this);
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
        // if current puzzle is last puzzle
        TransitionTo(_endState);

        // else
        // currentPuzzle = nextPuzzle
        // TransitionTo(_puzzleActiveState)
    }

    private void TransitionTo(IGameState nextState)
    {
        Debug.Log($"Updating game state from { CurrentGameState } to { nextState }");
        CurrentGameState = nextState;
        nextState.Enter();
    }
}
