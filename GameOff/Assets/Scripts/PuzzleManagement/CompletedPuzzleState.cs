public class CompletedPuzzleState : IPuzzleState
{
    public void Enter(IPuzzle puzzle)
    {
        puzzle.PuzzleComponents.ForEach(p => p.SetEnabled(false));
    }
}
