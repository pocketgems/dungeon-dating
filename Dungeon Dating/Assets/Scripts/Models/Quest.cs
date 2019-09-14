public class Quest
{
    public Character enemy;
    public ItemQuantity reward;

    public Quest(Character enemy, ItemQuantity reward)
    {
        this.enemy = enemy;
        this.reward = reward;
    }
}
