using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<HealthImage> _healthImages;

    private void OnEnable()
    {
        _player.HealthDecreased += OnHealthDecreased;
        _player.HealthIncreased += OnHealthIncreased;
    }

    private void OnDisable()
    {
        _player.HealthDecreased -= OnHealthDecreased;
        _player.HealthIncreased -= OnHealthIncreased;
    }

    private void OnHealthDecreased(int health)
    {
        for (int i = 0; i < health; i++)
        {
            _healthImages[health].SetEmptyHealth();
        }
    }

    private void OnHealthIncreased(int health)
    {
        for (int i = 0; i < health; i++)
        {
            _healthImages[health - 1].SetFullHealth();
        }
    }
}