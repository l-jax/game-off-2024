public class InactivePuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public InactivePuzzleState(IPuzzle puzzle) {
        this._puzzle = puzzle;
    }

    public void Enter()
    {
        _puzzle.Reset();
    }
}