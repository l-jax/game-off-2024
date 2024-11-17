using UnityEngine;

public class CompletedPuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public CompletedPuzzleState(IPuzzle puzzle) {
        this._puzzle = puzzle;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
