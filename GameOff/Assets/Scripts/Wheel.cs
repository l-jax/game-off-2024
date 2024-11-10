using System;
using UnityEngine;

public class Wheel : MonoBehaviour, IRotatable
{
    public bool AtTargetRotation => _currentStep == _targetStep;

    [SerializeField]
    private Axis _axis = Axis.X;

    [SerializeField]
    [Min(1)]
    private int _stepsForFullRotation = 4;

    [SerializeField]
    [Min(0)]
    private int _targetStep = 0;

    private int _currentStep = 0;

    public void OnValidate()
    {
        if (_targetStep >= _stepsForFullRotation) {
            throw new ArgumentOutOfRangeException($"Target Step {_targetStep} must be less than Steps For Full Rotation {_stepsForFullRotation}");
        }
    }

    public void OnMouseDown() {
        // debug
        Rotate();
    }

    public void Rotate()
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
    }
}
