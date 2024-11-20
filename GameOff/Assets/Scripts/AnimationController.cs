using System.Linq;
using UnityEngine;

public class AnimationController : MonoBehaviour 
{
    private Animation _animation;

    public void Start()
    {
        _animation = GetComponent<Animation>();

        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnStart += OnPuzzleStart);
    }

    private void OnPuzzleStart(IPuzzle puzzle)
    {
        _animation.Play(puzzle.Name);
        puzzle.OnStart -= OnPuzzleStart;
    }
}