using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    private Camera _mainCamera;

    public void Start()
    {
        _mainCamera = Camera.main;

        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnStart += OnPuzzleStart);
    }

    private void OnPuzzleStart(IPuzzle puzzle)
    {
        _mainCamera.transform.SetPositionAndRotation(puzzle.EmptyCameraTransform.position, puzzle.EmptyCameraTransform.rotation);
        puzzle.OnStart -= OnPuzzleStart;
    }
}