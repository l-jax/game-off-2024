using System;
using System.Collections.Generic;

public interface IPuzzle
{
    event Action<IPuzzle> OnComplete;
    List<IPuzzleComponent> PuzzleComponents { get; }
    void SetCompleted();
}