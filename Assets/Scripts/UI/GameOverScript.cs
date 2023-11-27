using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    [SerializeField] private TextMeshProUGUI _gameOverHighScoreText;

    private CanvasGroup _gameOverGroup;
    private int _visibleAlpha = 1;
    private int _invisibleAlpha = 0;
    private int _sceneIndex;

    private void Awake()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = _invisibleAlpha;
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnDied()
    {
        _scoreCounter.SetMaxScore();
        _gameOverScoreText.text = $"{_scoreCounter.Score}.";
        _gameOverHighScoreText.text = $"{_scoreCounter.MaxScore}.";
        _gameOverGroup.alpha = _visibleAlpha;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex);
    }
}