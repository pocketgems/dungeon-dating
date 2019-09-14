public class PunchOption : CombatOption
{
    public PunchOption() : base("Punch")
    {
    }

    public override void Execute()
    {
        var enemy = AdventureManager.instance.branch.currentSituation.enemy;
        if (SpeedUtility.Success(AdventureManager.instance.playerFighter.speed, enemy.speed))
        {
            enemy.health -= AdventureManager.instance.playerFighter.attack;
        }

        AdventureManager.instance.AdvanceCombatState();
    }
}
