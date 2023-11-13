using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private void OnEnable()
    {
       _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
