public class InProgressPuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public InProgressPuzzleState(IPuzzle puzzle) {
        this._puzzle = puzzle;
    }

    public void Enter()
    {
        _puzzle.Enable();
    }
}