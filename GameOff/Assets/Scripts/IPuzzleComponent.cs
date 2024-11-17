using System;

public interface IPuzzleComponent
{
    public bool AtTarget { get; }
    public event Action OnTargetReached;
    public void Step ();
    public void Reset();
    public void SetEnabled(bool enabled);
}