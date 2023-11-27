using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            TurnOn(player);
            Die();
        }

        if (collision.TryGetComponent(out Destroyer destroyer))
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public abstract void TurnOn(Player player);
}