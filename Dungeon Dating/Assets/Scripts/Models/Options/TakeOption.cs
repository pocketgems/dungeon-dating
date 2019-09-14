public class TakeOption : Option
{
    public ItemQuantity itemQuantity;

    public override void Execute()
    {
        if (Player.instance.TryAddItem(itemQuantity))
        {
            AdventureManager.instance.branch.currentSituation.items.Remove(itemQuantity);
            AdventureManager.instance.Refresh();
        }
    }

    public TakeOption(ItemQuantity itemQuantity) : base(itemQuantity.item.name)
    {
        this.itemQuantity = itemQuantity;
    }
}
