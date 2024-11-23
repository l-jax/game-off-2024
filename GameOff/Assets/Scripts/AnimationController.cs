using System.Linq;
using UnityEngine;

public class AnimationController : MonoBehaviour 
{
    [SerializeField]
    private Animator _animator;

    public void Start()
    {
        GameObject.Find("GameController").GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnComplete += OnPuzzleComplete);
    }

    private void OnPuzzleComplete(IPuzzle puzzle)
    {
        _animator.Play(puzzle.Name);
        puzzle.OnComplete -= OnPuzzleComplete;
    }
}