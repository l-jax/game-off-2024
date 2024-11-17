using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour, IPuzzle
{
    public IPuzzleState CurrentState { get; private set; }
    public InactivePuzzleState InactiveState { get; private set; }
    public InProgressPuzzleState InProgressState { get; private set; }
    public CompletedPuzzleState CompletedPuzzleState { get; private set; }
    public List<IPuzzleComponent> PuzzleComponents { get; }
    public event Action<IPuzzle> OnComplete;

    public void Start() {
        this.InactiveState = new InactivePuzzleState();
        this.InProgressState = new InProgressPuzzleState();
        this.CompletedPuzzleState = new CompletedPuzzleState();

        Initialize();
    }

    public void SetCompleted() {
        TransitionTo(CompletedPuzzleState);
        OnComplete?.Invoke(this);
    }

    private void Initialize()
    {
        CurrentState = InactiveState;
        InactiveState.Enter(this);
        Debug.Log("Puzzle initialised");
    }

    private void TransitionTo(IPuzzleState nextState)
    {
        CurrentState = nextState;
        nextState.Enter(this);
    }
}
