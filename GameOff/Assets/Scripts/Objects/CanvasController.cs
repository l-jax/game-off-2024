using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private string _winText = "You win";
    [SerializeField]
    private string _loseText = "Time's Up";
    [SerializeField]
    private Canvas _canvas;
    private TextMeshProUGUI _textMeshProUGUI;
    private GameManager _gameManager;

    public void Start()
    {
        _textMeshProUGUI = _canvas.GetComponentInChildren<TextMeshProUGUI>();
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        _gameManager.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool playerLost) 
    {
        _textMeshProUGUI.text = playerLost ? _loseText : _winText;
        _canvas.gameObject.SetActive(true);
    }
}
