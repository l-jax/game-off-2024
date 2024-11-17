using System;
using UnityEngine;

[Serializable]
public class PuzzleStateMachine
{
    public IPuzzleState CurrentState { get; private set; }
    private readonly InactivePuzzleState _inactiveState;
    private readonly InProgressPuzzleState _inProgressState;
    private readonly CompletedPuzzleState _completedPuzzleState;
    
    public PuzzleStateMachine(IPuzzle puzzle)
    {
        this._inactiveState = new InactivePuzzleState(puzzle);
        this._inProgressState = new InProgressPuzzleState(puzzle);
        this._completedPuzzleState = new CompletedPuzzleState(puzzle);
    }

    public void Initialize(IPuzzleState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }
    public void TransitionTo(IPuzzleState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }
    public void Update()
    {
        CurrentState?.Update();
    }
}

public interface IPuzzle
{
}