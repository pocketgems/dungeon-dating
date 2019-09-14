public class FinishOption : MoveOption
{
    public FinishOption() : base("Finish")
    {
    }

    public override void Execute()
    {
        AdventureManager.instance.AddHearts(5, "Hooray! We finished the dungeon!");
        AdventureManager.instance.ShowRelationshipSummary();
    }
}
