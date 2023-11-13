using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Shield _shield;

    private int _maxHealth;

    public event UnityAction<int> HealthDecreased;    
    public event UnityAction<int> HealthIncreased;
    public event UnityAction Died;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthDecreased?.Invoke(_health);

        if( _health <= 0)
        {
            Die();
        }
    }

    public void ActivateShield()
    {
        _shield.gameObject.SetActive(true);
    }

    public void IncreaseHealth(int healthToIncrease)
    {
        _health = Mathf.Clamp(_health + healthToIncrease, 0, _maxHealth);
        HealthIncreased?.Invoke(_health);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
