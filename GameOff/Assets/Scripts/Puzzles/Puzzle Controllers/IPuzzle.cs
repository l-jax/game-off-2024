using System;
using System.Collections.Generic;

public interface IPuzzle
{
    event Action<IPuzzle> OnComplete;
    public string Name { get; }
    List<IPuzzleComponent> PuzzleComponents { get; }
    internal void StartPuzzle();
    internal void SetCompleted();
}