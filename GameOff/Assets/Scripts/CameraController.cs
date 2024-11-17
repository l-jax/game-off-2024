using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;

    public void Awake() {
        _mainCamera = Camera.main;
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    public void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState state)
    {
        // TODO: handle camera movement
        // GameState.Start -> PuzzleActive move to first puzzle
        // GameState.PuzzleActive -> PuzzleSolved move between puzzles
        // GameState.PuzzleSolved -> Win/Lost move to final position
    }
}
