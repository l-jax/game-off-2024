using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private float _lookSpeed = 3;

    private Camera _mainCamera;
    private Vector2 _rotation = Vector2.zero;

    public void Start()
    {
        _mainCamera = Camera.main;

        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnStart += OnPuzzleStart);
    }

    public void Update () {
		_rotation.y += Input.GetAxis ("Mouse X");
		_rotation.x += -Input.GetAxis ("Mouse Y");
		_mainCamera.transform.eulerAngles = _rotation * _lookSpeed;
	}

    private void OnPuzzleStart(IPuzzle puzzle)
    {
        _mainCamera.transform.SetPositionAndRotation(puzzle.EmptyCameraTransform.position, puzzle.EmptyCameraTransform.rotation);
        puzzle.OnStart -= OnPuzzleStart;
    }
}