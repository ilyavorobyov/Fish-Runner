using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _secondsToAddScore;
    [SerializeField] private int _scoreToRiseSpeed;

    private WaitForSeconds _waitForUpdateScore;

    public event UnityAction<int> ScoreChanged;

    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    private void Awake()
    {
        _waitForUpdateScore = new WaitForSeconds(_secondsToAddScore);

        MaxScore = PlayerPrefs.GetInt("MaxScore", 0);

        Score = 0;
    }

    private void Start()
    {
        ScoreChanged?.Invoke(Score);
        StartCoroutine(UpdateScore());
    }

    public void SetMaxScore()
    {
        if(Score >= MaxScore)
        {
            MaxScore = Score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);
            PlayerPrefs.Save();
        }
    }

    private IEnumerator UpdateScore()
    {
        while(Time.timeScale != 0)
        {
            if (Score % _scoreToRiseSpeed == 0 && Score != 0)
            {
                Time.timeScale += 0.2f;
            }

            Score += _scoreToAdd;
            ScoreChanged?.Invoke(Score);

            yield return _waitForUpdateScore;
        }
    }
}
