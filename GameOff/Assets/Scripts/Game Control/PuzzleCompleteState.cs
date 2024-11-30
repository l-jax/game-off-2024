public class PuzzleCompleteState : IGameState
{
    private readonly GameManager _gameManager;

    public PuzzleCompleteState(GameManager manager) 
    {
        _gameManager = manager;
    }

    public void Enter()
    {
        _gameManager.NextPuzzleOrEndGame();
    }

    public void Update()
    {
        
    }
}