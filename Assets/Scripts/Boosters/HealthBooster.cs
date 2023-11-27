using UnityEngine;

public class HealthBooster : Booster
{
    [SerializeField] private int _healthToIncrease;

    public override void TurnOn(Player player)
    {
        player.IncreaseHealth(_healthToIncrease);
    }
}