public class InactivePuzzleState : IPuzzleState
{
    public void Enter(IPuzzle puzzle)
    {
        puzzle.PuzzleComponents.ForEach(p => p.Reset());
    }
}