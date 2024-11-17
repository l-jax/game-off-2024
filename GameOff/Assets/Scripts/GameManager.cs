using System;
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

    public void Awake() {
        Instance = this;
    }

    public void UpdateGameState(GameState state) {
        if (State == state) return;
        
        State = state;

        switch(state) {
            case GameState.Start:
            break;
            case GameState.PuzzleActive:
            break;
            case GameState.PuzzleComplete:
            break;
            case GameState.Win:
            break;
            case GameState.Lose:
            break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state));
        }

        OnGameStateChanged?.Invoke(state);
    }
}
