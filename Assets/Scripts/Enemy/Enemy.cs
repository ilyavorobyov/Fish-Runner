using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        if(collision.TryGetComponent(out Shield shield))
        {
            shield.TakeDamage();
        }

        if( !collision.TryGetComponent(out SpawnableObject spawnableObject))
        {
            Die();
        } 
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
