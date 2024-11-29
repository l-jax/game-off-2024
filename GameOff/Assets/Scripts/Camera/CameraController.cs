using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private float _lookSpeed = 3;
    [SerializeField]
    private float _moveSpeed = 3;

    private GameManager _gameManager;
    private Camera _mainCamera;
    private Vector2 _rotation = Vector2.zero;
    private bool _isMoving = false;
    private bool _canLook = false;
    private Vector3 _targetPosition;

    public void Start()
    {
        _mainCamera = Camera.main;
        _targetPosition = _mainCamera.transform.position;

        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnStart += OnPuzzleStart);
        
        _gameManager = GetComponent<GameManager>();
        _gameManager.OnGameEnd += OnGameEnd;
    }

    public void Update()
    {
        if (_canLook) {
            _rotation.y += Input.GetAxis ("Mouse X");
            _rotation.x += -Input.GetAxis ("Mouse Y");
            _mainCamera.transform.eulerAngles = _rotation * _lookSpeed;
        }

        if (_isMoving) {
            _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }

        if (_mainCamera.transform.position == _targetPosition) {
            _isMoving = false;
        }
    }

    private void OnPuzzleStart(IPuzzle puzzle)
    {
        _targetPosition = puzzle.EmptyCameraTransform.position;
        _isMoving = true;
        _canLook = true;
    
        puzzle.OnStart -= OnPuzzleStart;
    }

    private void OnGameEnd()
    {
        _canLook = false;
    }
}