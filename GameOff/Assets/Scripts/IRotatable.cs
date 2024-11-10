using Unity.Mathematics;

public interface IRotatable
{
    public bool AtTargetRotation { get; }
    public void Rotate ();
}