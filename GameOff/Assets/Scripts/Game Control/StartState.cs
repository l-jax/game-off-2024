using UnityEngine;

public class StartState : IGameState
{
    private readonly GameManager _gameManager;

    public StartState(GameManager gameManager) 
    {
        _gameManager = gameManager;
    }

    public void Enter()
    {
        // start some music or something
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Starting game");
            _gameManager.StartGame();
        }
    }
}