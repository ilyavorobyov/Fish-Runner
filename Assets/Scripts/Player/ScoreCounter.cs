using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _secondsToAddScore;
    [SerializeField] private int _scoreToRiseSpeed;

    private const string MaxResult = "MaxScore";

    private Coroutine _updateScore;
    private float _speedBoost = 0.2f;
    private int _startScore = 0;

    public event UnityAction<int> ScoreChanged;

    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    private void Awake()
    {
        MaxScore = PlayerPrefs.GetInt(MaxResult, 0);
        Score = _startScore;
    }

    private void Start()
    {
        ScoreChanged?.Invoke(Score);

        if (_updateScore != null)
            StopCoroutine(_updateScore);

        _updateScore = StartCoroutine(UpdateScore());
    }

    public void SetMaxScore()
    {
        if (Score >= MaxScore)
        {
            MaxScore = Score;
            PlayerPrefs.SetInt(MaxResult, MaxScore);
        }
    }

    private IEnumerator UpdateScore()
    {
        var waitForNewUpdateScore = new WaitForSeconds(_secondsToAddScore);

        while (Time.timeScale != 0)
        {
            if (Score % _scoreToRiseSpeed == 0 && Score != 0)
            {
                Time.timeScale += _speedBoost;
            }

            Score += _scoreToAdd;
            ScoreChanged?.Invoke(Score);
            yield return waitForNewUpdateScore;
        }
    }
}