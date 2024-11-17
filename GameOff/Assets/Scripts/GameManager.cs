using System;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Start,
    PuzzleActive,
    PuzzleComplete,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    public static event Action<GameState> OnGameStateChanged;

    public GameState State { get; private set;} = GameState.Start;

    [SerializeField]
    private readonly List<IPuzzle> _puzzles;
    private int _currentPuzzle = 0;

    public void Awake() {
        Instance = this;
    }

    public void UpdateGameState(GameState state) {
        if (State == state) return;
        
        State = state;

        switch(state) {
            case GameState.Start:
                // TODO: start the game
            break;
            case GameState.PuzzleActive:
                _currentPuzzle ++;
                _puzzles[_currentPuzzle].PuzzleStateMachine.Initialize();
            break;
            case GameState.PuzzleComplete:
                // TODO: complete the current puzzle, check if win/lose condition met
                if (_currentPuzzle +1 == _puzzles.Count) {
                    // this was the last puzzle
                }
            break;
            case GameState.Win:
                // TODO: finish the game and display win
            break;
            case GameState.Lose:
                // TODO: finish the game and display lose
            break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state));
        }

        OnGameStateChanged?.Invoke(state);
    }
}
