using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : MonoBehaviour
{
    [SerializeField] private int _healthToIncrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.IncreaseHealth(_healthToIncrease);
        }

        if (!collision.TryGetComponent(out Enemy enemy))
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
