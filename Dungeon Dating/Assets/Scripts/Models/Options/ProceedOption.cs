public class ProceedOption : MoveOption
{
    public ProceedOption() : base("Onwards")
    {
    }

    public override void Execute()
    {
        AdventureManager.instance.branch.Advance();
    }
}
