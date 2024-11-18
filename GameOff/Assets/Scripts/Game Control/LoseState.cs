public class LoseState : IGameState
{
    private readonly GameManager _gameManager;

    public LoseState(GameManager manager) 
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