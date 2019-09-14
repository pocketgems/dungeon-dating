public class OpenOption : Option
{
    public Chest chest;

    public OpenOption(Chest chest) : base(chest.unlockDescription)
    {
        this.chest = chest;
    }

    public override void Execute()
    {
        if (chest.key.HasValue)
        {
            if (Player.instance.CanRemoveItem(chest.key.Value))
            {
                Player.instance.TryRemoveItem(chest.key.Value);
                AdventureManager.instance.branch.currentSituation.items.AddRange(chest.GenerateLoot());
                AdventureManager.instance.branch.currentSituation.chest = null;
                AdventureManager.instance.Refresh();
            }
        }
        else
        {
            AdventureManager.instance.branch.currentSituation.items.AddRange(chest.GenerateLoot());
            AdventureManager.instance.branch.currentSituation.chest = null;
            AdventureManager.instance.Refresh();
        }
    }
}
