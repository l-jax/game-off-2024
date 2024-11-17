using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour, IPuzzle
{
    public event Action<IPuzzle> OnComplete;
    public string Name { get => gameObject.name; }
    public List<IPuzzleComponent> PuzzleComponents { get; } = new();
    public IPuzzleState CurrentState { get; private set; }
    public InactivePuzzleState InactiveState { get; private set; }
    public InProgressPuzzleState InProgressState { get; private set; }
    public CompletedPuzzleState CompletedPuzzleState { get; private set; }

    public void Start()
    {
        this.InactiveState = new InactivePuzzleState(this);
        this.InProgressState = new InProgressPuzzleState(this);
        this.CompletedPuzzleState = new CompletedPuzzleState(this);

        GameObject.FindGameObjectsWithTag(Name).ToList()
            .ForEach(g => PuzzleComponents.Add(g.GetComponent<IPuzzleComponent>()));

        Debug.Log($"Found { PuzzleComponents.Count } components for puzzle { Name }");

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
        InactiveState.Enter();
        Debug.Log("Puzzle initialised");
    }

    private void TransitionTo(IPuzzleState nextState)
    {
        Debug.Log($"Updating puzzle state from { CurrentState } to { nextState }");
        CurrentState = nextState;
        nextState.Enter();
    }
}
