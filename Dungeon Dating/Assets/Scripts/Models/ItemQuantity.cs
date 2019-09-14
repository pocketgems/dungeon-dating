public struct ItemQuantity
{
    public Item item;
    public int quantity;
    public int durabilityRemaining;

    public ItemQuantity(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        durabilityRemaining = item.durability;
    }

    public ItemQuantity(Item item, int quantity, int durabilityRemaining)
    {
        this.item = item;
        this.quantity = quantity;
        this.durabilityRemaining = durabilityRemaining;
    }
}
