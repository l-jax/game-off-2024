public class CompletedPuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;
    
    public CompletedPuzzleState(IPuzzle puzzle)
    {
        _puzzle = puzzle;
    }
    public void Enter()
    {
        _puzzle.PuzzleComponents.ForEach(p => p.SetEnabled(false));
    }
}
