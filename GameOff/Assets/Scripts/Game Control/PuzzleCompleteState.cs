public class PuzzleCompleteState : IGameState
{
    private readonly GameManager _gameManager;

    public PuzzleCompleteState(GameManager manager) 
    {
        _gameManager = manager;
    }

    public void Enter()
    {
        // start puzzle completion thing
    }

    public void Update()
    {
        // finish up the thing
        // set next puzzle 
        _gameManager.NextPuzzleOrEndGame();
    }
}