public interface IPuzzle
{
    public PuzzleStateMachine PuzzleStateMachine { get; }
    public void Enable();
    public void Disable();
    public void Reset();
    public void Check();
}