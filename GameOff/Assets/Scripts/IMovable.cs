using UnityEngine;

public interface IMovable
{
    public bool AtTargetPosition { get; }
    public void Move ();
}