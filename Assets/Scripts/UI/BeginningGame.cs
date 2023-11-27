using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginningGame : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private int _gameSceneNumber = 1;

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
        SceneManager.LoadScene(_gameSceneNumber);
    }
}