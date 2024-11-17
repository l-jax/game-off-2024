public class CompletedPuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public CompletedPuzzleState(IPuzzle puzzle) {
        this._puzzle = puzzle;
    }

    public void Enter()
    {
        _puzzle.Disable();
        // publish completed state
    }
}
