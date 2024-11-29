using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private float _lookSpeed = 3;
    [SerializeField]
    private float _moveSpeed = 3;

    private Camera _mainCamera;
    private Vector2 _rotation = Vector2.zero;
    private bool _isMoving = false;
    private Vector3 _targetPosition;

    public void Start()
    {
        _mainCamera = Camera.main;
        _targetPosition = _mainCamera.transform.position;

        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnStart += OnPuzzleStart);
    }

    public void Update () {
		_rotation.y += Input.GetAxis ("Mouse X");
		_rotation.x += -Input.GetAxis ("Mouse Y");
		_mainCamera.transform.eulerAngles = _rotation * _lookSpeed;

        if (!_isMoving) {
            return;
        }

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        if (_mainCamera.transform.position == _targetPosition) {
            _isMoving = false;
        }
    
    }

    private void OnPuzzleStart(IPuzzle puzzle)
    {
        //_mainCamera.transform.SetPositionAndRotation(puzzle.EmptyCameraTransform.position, puzzle.EmptyCameraTransform.rotation);
        _targetPosition = puzzle.EmptyCameraTransform.position;
        _isMoving = true;
    
        puzzle.OnStart -= OnPuzzleStart;
    }
}