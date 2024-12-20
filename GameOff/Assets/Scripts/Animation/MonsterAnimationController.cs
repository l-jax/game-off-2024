using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _gameManager.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool playerLost)
    {
        if (playerLost) {
            _animator.Play("Lose");
        } else {
            _animator.Play("Win");
        }
        
        _gameManager.OnGameOver -= OnGameOver;
    }
}
