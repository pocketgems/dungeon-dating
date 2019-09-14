public abstract class Option
{
    public readonly string title;

    public Option(string title)
    {
        this.title = title;
    }

    public abstract void Execute();
}
