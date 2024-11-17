using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour, IPuzzle
{
    public event Action<IPuzzle> OnComplete;
    public string Name { get => "TEST"; }
    public List<IPuzzleComponent> PuzzleComponents { get => _puzzleComponents.ToList(); }
    public IPuzzleState CurrentState { get; private set; }
    public InactivePuzzleState InactiveState { get; private set; }
    public InProgressPuzzleState InProgressState { get; private set; }
    public CompletedPuzzleState CompletedPuzzleState { get; private set; }

    [SerializeReference]
    private IPuzzleComponent[] _puzzleComponents;

    public void Start()
    {
        this.InactiveState = new InactivePuzzleState();
        this.InProgressState = new InProgressPuzzleState();
        this.CompletedPuzzleState = new CompletedPuzzleState();

        Initialize();
    }

    public void SetCompleted()
    {
        TransitionTo(CompletedPuzzleState);
        Debug.Log("Puzzle complete");
        OnComplete?.Invoke(this);
    }

    public void StartPuzzle()
    {
        TransitionTo(InProgressState);
    }

    private void Initialize()
    {
        CurrentState = InactiveState;
        InactiveState.Enter(this);
        Debug.Log("Puzzle initialised");
    }

    private void TransitionTo(IPuzzleState nextState)
    {
        Debug.Log($"Updating puzzle state from { CurrentState } to { nextState }");
        CurrentState = nextState;
        nextState.Enter(this);
    }
}
