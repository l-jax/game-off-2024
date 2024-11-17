public class PuzzleActiveState : IGameState
{
    private readonly GameManager _gameManager;

    public PuzzleActiveState(GameManager manager) 
    {
        _gameManager = manager;
    }

    public void Enter()
    {
        _gameManager.CurrentPuzzle.OnComplete += OnPuzzleComplete;
        _gameManager.CurrentPuzzle.StartPuzzle();
    }

    public void Update()
    {
        // play some sounds or something
    }

    private void OnPuzzleComplete(IPuzzle puzzle) 
    {
        puzzle.OnComplete -= OnPuzzleComplete;
        _gameManager.CompletePuzzle(puzzle);
    } 
}