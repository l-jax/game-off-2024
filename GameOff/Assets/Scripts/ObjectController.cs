using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _objectsToInactivateOnStart;

    [SerializeField]
    private List<GameObject> _objectsToInactivateOnEnd;

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _gameManager.OnGameStart += OnGameStart;
        _gameManager.OnGameEnd += OnGameEnd;
    }

    private void OnGameStart()
    {
        foreach (GameObject item in _objectsToInactivateOnStart)
        {
            item.SetActive(false);
        }
        _gameManager.OnGameStart -= OnGameStart;
    }

    private void OnGameEnd()
    {
        foreach (GameObject item in _objectsToInactivateOnEnd)
        {
            item.SetActive(false);
        }
        _gameManager.OnGameEnd -= OnGameEnd;
    }
}
