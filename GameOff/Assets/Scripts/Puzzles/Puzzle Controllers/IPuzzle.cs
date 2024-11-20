using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle
{
    event Action<IPuzzle> OnStart;
    event Action<IPuzzle> OnComplete;
    string Name { get; }
    Transform EmptyCameraTransform { get; }
    List<IPuzzleComponent> PuzzleComponents { get; }
    void StartPuzzle();
    void SetCompleted();
}