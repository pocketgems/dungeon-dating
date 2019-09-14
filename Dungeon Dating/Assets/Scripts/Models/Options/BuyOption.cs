public class BuyOption : Option
{
    private Item item;

    public BuyOption(Item item) : base(item.name)
    {
        this.item = item;
    }

    public override void Execute()
    {
        if (Player.instance.gold >= item.value)
        {
            Player.instance.gold -= item.value;
            Player.instance.TryAddItem(new ItemQuantity(item, 1));
        }
    }
}
