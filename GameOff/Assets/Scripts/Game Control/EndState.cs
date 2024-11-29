public class EndState : IGameState
{
    private readonly GameManager _gameManager;

    public EndState(GameManager manager) 
    {
        _gameManager = manager;
    }

    public void Enter()
    {
        _gameManager.EndGame();
    }

    public void Update()
    {
        // something
    }
}