using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Character character;
    public Dictionary<string, ItemQuantity> itemQuantitiesByName = new Dictionary<string, ItemQuantity>();
    public HashSet<Companion> companionsToMeetAgain = new HashSet<Companion>();
    public int gold = 100;

    public Gender? gender;

    public int energy;
    public int maxEnergy = 100;

    private void Awake()
    {
        instance = this;
        energy = maxEnergy;
    }

    public IEnumerable<ItemQuantity> ItemsOfType(Item.Type itemType)
    {
        List<ItemQuantity> itemQuantities = new List<ItemQuantity>();

        foreach (var itemQuantity in itemQuantitiesByName.Values)
        {
            if (((itemQuantity.durabilityRemaining > 0) || (itemQuantity.item.durability == 0)) && (itemQuantity.quantity > 0))
            {
                if (itemQuantity.item.types.Contains(itemType))
                {
                    itemQuantities.Add(itemQuantity);
                }
            }
        }

        return itemQuantities;
    }

    public ItemQuantity GetQuantity(Item item)
    {
        ItemQuantity itemQuantity;
        if (itemQuantitiesByName.TryGetValue(item.name, out itemQuantity))
        {
            return itemQuantity;
        }
        else
        {
            return new ItemQuantity(item, 0);
        }
    }

    public void LoseDurability(Item item)
    {
        ItemQuantity itemQuantity;
        if (itemQuantitiesByName.TryGetValue(item.name, out itemQuantity))
        {
            int newDurability = itemQuantity.durabilityRemaining - 1;

            if (newDurability > 0)
            {
                itemQuantitiesByName[item.name] = new ItemQuantity(item, itemQuantity.quantity, newDurability);
            }
            else
            {
                itemQuantitiesByName.Remove(item.name);
            }
        }
    }

    public bool CanAddItem(ItemQuantity itemQuantity)
    {
        return true;
    }

    public bool TryAddItem(ItemQuantity itemQuantity)
    {
        ItemQuantity ownedItemQuantity;
        if (itemQuantitiesByName.TryGetValue(itemQuantity.item.name, out ownedItemQuantity))
        {
            itemQuantitiesByName[ownedItemQuantity.item.name] = new ItemQuantity(ownedItemQuantity.item, ownedItemQuantity.quantity + itemQuantity.quantity);
        }
        else
        {
            itemQuantitiesByName[itemQuantity.item.name] = itemQuantity;
        }

        return true;
    }

    public bool CanRemoveItem(ItemQuantity itemQuantity)
    {
        ItemQuantity ownedItemQuantity;
        if (itemQuantitiesByName.TryGetValue(itemQuantity.item.name, out ownedItemQuantity))
        {
            if (ownedItemQuantity.quantity >= itemQuantity.quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool TryRemoveItem(ItemQuantity itemQuantity)
    {
        ItemQuantity ownedItemQuantity;
        if (itemQuantitiesByName.TryGetValue(itemQuantity.item.name, out ownedItemQuantity))
        {
            if (ownedItemQuantity.quantity >= itemQuantity.quantity)
            {
                ownedItemQuantity.quantity -= itemQuantity.quantity;
                itemQuantitiesByName[ownedItemQuantity.item.name] = ownedItemQuantity;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
