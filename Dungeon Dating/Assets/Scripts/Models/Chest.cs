using System.Collections.Generic;

public class Chest
{
    public string description;
    public string unlockDescription;
    public ItemQuantity? key;
    public List<ItemQuantity> items;

    public Chest(string description, string unlockDescription, ItemQuantity? key, params ItemQuantity[] items)
    {
        this.description = description;
        this.unlockDescription = unlockDescription;
        this.key = key;
        this.items = new List<ItemQuantity>();
        this.items.AddRange(items);
    }

    public virtual IEnumerable<ItemQuantity> GenerateLoot()
    {
        List<ItemQuantity> loot = new List<ItemQuantity>();
        loot.Add(items[UnityEngine.Random.Range(0, items.Count)]);
        return loot;
    }
}
