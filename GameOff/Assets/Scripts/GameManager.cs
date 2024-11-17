using System;
using UnityEngine;

public enum GameState {
    Start,
    Active,
    Win
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    public static event Action<GameState> OnGameStateChanged;

    public GameState State { get; private set;} = GameState.Start;

    public IPuzzle Puzzle { get; private set; }

    public void Awake() {
        Instance = this;
        Puzzle = this.GetComponent<IPuzzle>();
    }

    public void UpdateGameState(GameState state) {
        if (State == state) return;
        
        State = state;

        switch(state) {
            case GameState.Start:
                
            break;
            case GameState.Active:
                Puzzle.OnComplete += OnPuzzleComplete;
            break;
            case GameState.Win:
                Puzzle.OnComplete -= OnPuzzleComplete;
            break;
        }

        OnGameStateChanged?.Invoke(state);
    }

    private void OnPuzzleComplete(IPuzzle puzzle) {
        UpdateGameState(GameState.Win);
    }
}
