using System.Collections.Generic;

public class EquipmentChest : Chest
{
    public EquipmentChest(string description, string unlockDescription, ItemQuantity? key, Item[] items) : base(description, unlockDescription, key)
    {
        foreach (var item in items)
        {
            this.items.Add(new ItemQuantity(item, 1));
        }
    }

    public override IEnumerable<ItemQuantity> GenerateLoot()
    {
        List<ItemQuantity> loot = new List<ItemQuantity>();

        List<Item> itemsNotYetOwned = new List<Item>();
        foreach (var equippableItem in items)
        {
            var itemQuantity = Player.instance.GetQuantity(equippableItem.item);
            if ((itemQuantity.quantity > 0) && ((itemQuantity.item.durability == 0) || (itemQuantity.durabilityRemaining > 0)))
            {
                continue;
            }

            itemsNotYetOwned.Add(equippableItem.item);
        }

        var randomItem = itemsNotYetOwned[UnityEngine.Random.Range(0, itemsNotYetOwned.Count)];
        loot.Add(new ItemQuantity(randomItem, 1));
        return loot;
    }
}
