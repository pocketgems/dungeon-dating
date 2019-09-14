public class DodgeOption : CombatOption
{
    public DodgeOption() : base("Dodge")
    {
    }

    public override void Execute()
    {
        var enemy = AdventureManager.instance.branch.currentSituation.enemy;
        if (SpeedUtility.Success(AdventureManager.instance.playerFighter.speed, enemy.speed))
        {
            AdventureManager.instance.playerFighter.health -= enemy.attack;
        }

        AdventureManager.instance.AdvanceCombatState();
    }
}
