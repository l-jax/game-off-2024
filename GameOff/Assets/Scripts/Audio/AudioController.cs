using System.Linq;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
    [SerializeField]
    private AudioSource _audioSourceEnd;

    [SerializeField]
    private AudioSource _audioSourceFx;

    [SerializeField]
    private AudioSource _audioSourceMusic;
    private GameManager _gameManager;

    public void Start()
    {
        GetComponentsInChildren<IPuzzle>().ToList()
            .ForEach(puzzle => puzzle.OnComplete += OnPuzzleComplete);

        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _gameManager.OnGameOver += OnGameOver;
        
        _audioSourceMusic.loop = true;
        _audioSourceMusic.Play();
    }

    private void OnPuzzleComplete(IPuzzle puzzle)
    {
        _audioSourceFx.Play();
        puzzle.OnComplete -= OnPuzzleComplete;
    }

    private void OnGameOver(bool playerLost)
    {
        _audioSourceMusic.Stop();
        _audioSourceEnd.Play();
        _gameManager.OnGameOver -= OnGameOver;
    }
}
