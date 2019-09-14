public class FleeMenuOption : CombatOption
{
    public FleeMenuOption() : base("Flee")
    {
    }

    public override void Execute()
    {
        // TODO: lose some stuff?
        AdventureManager.instance.branch.Advance();
    }
}
