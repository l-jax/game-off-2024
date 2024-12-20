using UnityEngine;

public class PuzzleActiveState : IGameState
{
    private readonly GameManager _gameManager;
    private readonly TimeDisplay _timeDisplay;

    private float _timeRemainingSeconds;

    public PuzzleActiveState(GameManager manager, TimeDisplay timeDisplay, float timeRemainingSeconds) 
    {
        _gameManager = manager;
        _timeRemainingSeconds = timeRemainingSeconds;
        _timeDisplay = timeDisplay;
    }

    public void Enter()
    {
        _gameManager.CurrentPuzzle.OnComplete += OnPuzzleComplete;
        _gameManager.CurrentPuzzle.StartPuzzle();
    }

    public void Update()
    {
        if (_timeRemainingSeconds <= 0) {
            _gameManager.TimeUp();
            return;
        }

        _timeRemainingSeconds -= Time.deltaTime;
        _timeDisplay.DisplayTime(_timeRemainingSeconds);
    }

    private void OnPuzzleComplete(IPuzzle puzzle) 
    {
        puzzle.OnComplete -= OnPuzzleComplete;
        _gameManager.CompletePuzzle(puzzle);
    } 
}