using System.Linq;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
    [SerializeField]
    private AudioSource _audioSourceFx;

    [SerializeField]
    private AudioSource _audioSourceMusic;

    public void Start()
    {
        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnComplete += OnPuzzleComplete);
        
        _audioSourceMusic.loop = true;
        _audioSourceMusic.Play();
    }

    private void OnPuzzleComplete(IPuzzle puzzle)
    {
        _audioSourceFx.Play();
        puzzle.OnComplete -= OnPuzzleComplete;
    }
}
