using System;
using UnityEngine;

[Serializable]
public class RotatingPuzzleComponent : MonoBehaviour, IPuzzleComponent
{
    public event Action OnTargetReached;
    public bool AtTarget { get => _currentStep == _targetStep; }

    [SerializeField]
    private Axis _axis = Axis.X;

    [SerializeField]
    [Min(1)]
    private int _stepsForFullRotation = 4;
    
    [SerializeField]
    [Min(0)]
    private int _targetStep = 0;
    
    private int _currentStep = 0;
    private Quaternion _startRotation;
    private bool _enabled;

    public void Awake()
    {
        _startRotation = transform.rotation;
    }

    public void OnValidate()
    {
        if (_targetStep >= _stepsForFullRotation) {
            throw new ArgumentOutOfRangeException($"Target Step {_targetStep} must be less than Steps For Full Rotation {_stepsForFullRotation}");
        }
    }

    public void OnMouseDown()
    {
        if (_enabled) {
            Step();
        }
    }

    public void Step()
    {
        float stepAngle = 360f/_stepsForFullRotation;

        switch (_axis) {
            case Axis.X:
                transform.Rotate(stepAngle, 0, 0);
                break;
            case Axis.Y:
                transform.Rotate(0, stepAngle, 0);
                break;
            case Axis.Z:
                transform.Rotate(0, 0, stepAngle);
                break;
        }

        _currentStep = (_currentStep + 1) % _stepsForFullRotation;

        Debug.Log($"Puzzle component at step { _currentStep } target is { _targetStep }");

        if (AtTarget) {
            OnTargetReached?.Invoke();
        }
    }

    public void Reset()
    {
        transform.rotation = _startRotation;
        _currentStep = 0;
    }

    public void SetEnabled(bool enabled)
    {
        _enabled = enabled;
    }
}
