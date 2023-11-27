public class ShieldBooster : Booster
{
    public override void TurnOn(Player player)
    {
        player.ActivateShield();
    }
}