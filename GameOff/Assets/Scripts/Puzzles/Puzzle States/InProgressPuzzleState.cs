using System.Linq;

public class InProgressPuzzleState : IPuzzleState
{
    private readonly IPuzzle _puzzle;

    public InProgressPuzzleState(IPuzzle puzzle)
    {
        _puzzle = puzzle;
    }

    public void Enter()
    {
        _puzzle.PuzzleComponents.ForEach(p => p.OnTargetReached += Check);
        _puzzle.PuzzleComponents.ForEach(p => p.SetEnabled(true));
    }


    public void Check() 
    {
        if (!_puzzle.PuzzleComponents.All(puzzleComponents => puzzleComponents.AtTarget)) {
            return;
        }

        _puzzle.PuzzleComponents.ForEach(p => p.OnTargetReached -= Check);
        _puzzle.SetCompleted();
    }
}