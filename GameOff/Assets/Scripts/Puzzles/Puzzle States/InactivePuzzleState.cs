public class InactivePuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public InactivePuzzleState(IPuzzle puzzle)
    {
        _puzzle = puzzle;
    }

    public void Enter()
    {
        _puzzle.PuzzleComponents.ForEach(p => p.Reset());
    }
}