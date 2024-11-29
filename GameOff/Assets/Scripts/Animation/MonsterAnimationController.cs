using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _gameManager.OnGameEnd += OnGameEnd;
    }

    private void OnGameEnd()
    {
        _animator.Play("End");
        _gameManager.OnGameEnd -= OnGameEnd;
    }
}
