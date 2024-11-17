using System;

[Serializable]
public class PuzzleStateMachine
{
    public IPuzzleState CurrentState { get; private set; }
    public InactivePuzzleState InactiveState { get; }
    public InProgressPuzzleState InProgressState { get; }
    public CompletedPuzzleState CompletedPuzzleState { get; }
    
    public PuzzleStateMachine(IPuzzle puzzle)
    {
        this.InactiveState = new InactivePuzzleState(puzzle);
        this.InProgressState = new InProgressPuzzleState(puzzle);
        this.CompletedPuzzleState = new CompletedPuzzleState(puzzle);
    }

    public void Initialize()
    {
        CurrentState = InactiveState;
        InactiveState.Enter();
    }

    public void TransitionTo(IPuzzleState nextState)
    {
        CurrentState = nextState;
        nextState.Enter();
    }
}