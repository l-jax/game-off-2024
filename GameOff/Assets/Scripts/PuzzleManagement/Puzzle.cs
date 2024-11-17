using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour, IPuzzle
{
    public PuzzleStateMachine PuzzleStateMachine { get; private set; }

    [SerializeField]
    private readonly List<IPuzzleComponent> _puzzleComponents = new();

    public void Start() {
        PuzzleStateMachine = new PuzzleStateMachine(this);
        PuzzleStateMachine.Initialize();
        Debug.Log("Puzzle initialised");
    }

    public void Enable()
    {
        _puzzleComponents.ForEach(p => p.OnTargetReached += Check);
        _puzzleComponents.ForEach(p => p.SetEnabled(true));
        Debug.Log("Puzzle enabled");
    }

    public void Disable()
    {
        _puzzleComponents.ForEach(p => p.OnTargetReached -= Check);
        _puzzleComponents.ForEach(p => p.SetEnabled(false));
        Debug.Log("Puzzle disabled");
    }

    public void Check() 
    {
        Debug.Log("Checking Puzzle");
        if (!_puzzleComponents.All(_puzzleComponents => _puzzleComponents.AtTarget)) {
            Debug.Log($"Puzzle incomplete. { _puzzleComponents.Count(_puzzleComponents => _puzzleComponents.AtTarget) } of { _puzzleComponents.Count } components at target");
            return;
        }

        Debug.Log("All components at target. Transitioning puzzle to completed state.");
        PuzzleStateMachine.TransitionTo(PuzzleStateMachine.CompletedPuzzleState);
    }

    public void Reset()
    {
        _puzzleComponents.ForEach(p => p.Reset());
        Debug.Log("Puzzle reset");
    }
}
