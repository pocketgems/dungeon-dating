public class KillOption : CombatOption
{
    public KillOption() : base("Kill")
    {
    }

    public override void Execute()
    {
        var enemy = AdventureManager.instance.branch.currentSituation.enemy;
        if (enemy != null)
        {
            enemy.health = 0;
        }
    }
}
