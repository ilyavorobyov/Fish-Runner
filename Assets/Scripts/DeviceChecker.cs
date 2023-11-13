using UnityEngine;
using YG;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField] private GameObject _moveButtons;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += CheckUserDevice;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= CheckUserDevice;
    }

    private void CheckUserDevice()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            _moveButtons.SetActive(true);
            _playerInput.enabled = false;
        }
        else
        {
            _moveButtons.SetActive(false);
            _playerInput.enabled = true;
        }
    }

}