using System.Linq;
using UnityEngine;

public class AnimationController : MonoBehaviour 
{
    [SerializeField]
    private Animation _animation;

    public void Start()
    {
        GameObject.Find("GameController").GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnComplete += OnPuzzleComplete);
    }

    private void OnPuzzleComplete(IPuzzle puzzle)
    {
        _animation.Play(puzzle.Name);
        puzzle.OnComplete -= OnPuzzleComplete;
    }
}