public class ExploreOption : MoveOption
{
    public Branch branch;

    public ExploreOption(string title, Branch branch) : base(title)
    {
        this.branch = branch;
    }

    public override void Execute()
    {
        AdventureManager.instance.branch = branch;
    }
}
