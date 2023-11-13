using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBooster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ActivateShield();
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
