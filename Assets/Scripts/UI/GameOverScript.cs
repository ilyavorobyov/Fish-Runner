using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    [SerializeField] private TextMeshProUGUI _gameOverHighScoreText;
    [SerializeField] private GameObject _moveButtons;

    private CanvasGroup _gameOverGroup;

    private void Awake()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        _scoreCounter.SetMaxScore();

        _gameOverScoreText.text = $"{_scoreCounter.Score}.";
        _gameOverHighScoreText.text = $"{_scoreCounter.MaxScore}.";
       
        _moveButtons.SetActive(false);
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
