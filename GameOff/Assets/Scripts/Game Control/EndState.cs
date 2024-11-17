public class EndState : IGameState
{
    private readonly GameManager _gameManager;

    public EndState(GameManager manager) 
    {
        _gameManager = manager;
    }

    public void Enter()
    {
        // start the win thing
    }

    public void Update()
    {
        // listen for restart
    }
}