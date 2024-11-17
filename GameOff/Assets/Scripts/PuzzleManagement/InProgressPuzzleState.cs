using System.Linq;

public class InProgressPuzzleState : IPuzzleState
{
    private IPuzzle _puzzle;

    public void Enter(IPuzzle puzzle)
    {
        _puzzle = puzzle;
        puzzle.PuzzleComponents.ForEach(p => p.OnTargetReached += Check);
        puzzle.PuzzleComponents.ForEach(p => p.SetEnabled(true));
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