using UnityEngine;

public class InactivePuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public InactivePuzzleState(IPuzzle puzzle) {
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
