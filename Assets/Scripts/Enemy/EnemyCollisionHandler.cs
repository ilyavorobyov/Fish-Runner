using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage();
            _enemy.Die();
        }

        if (collision.TryGetComponent(out Shield shield))
        {
            shield.TakeDamage();
            _enemy.Die();
        }

        if (collision.TryGetComponent(out Destroyer destroyer))
        {
            _enemy.Die();
        }
    }
}