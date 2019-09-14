using System.Collections.Generic;

public class Item
{
    public enum Type
    {
        Weapon,
        Shield,
        Skill,
        Consumable,
        Key,
        Treasure,
        Currency
    }

    public string name;
    public int value;
    public int durability;
    public int attack;
    public int defense;
    public int speed;
    public HashSet<Type> types = new HashSet<Type>();

    public Item(string name, int value, int durability, int attack, int defense, int speed, params Type[] types)
    {
        this.name = name;
        this.value = value;
        this.durability = durability;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.types.UnionWith(types);
    }

    public static Item sword = new Item("Rusty Sword", 0, 8, 3, 2, 1, Type.Weapon, Type.Shield);
    public static Item axe = new Item("Rusty Axe", 0, 8, 5, 0, 0, Type.Weapon);
    public static Item dagger = new Item("Rusty Dagger", 0, 8, 2, 0, 2, Type.Weapon);
    public static Item shield = new Item("Wooden Shield", 0, 8, 0, 2, 0, Type.Shield);
    public static Item uncommonSword = new Item("Iron Sword", 50, 10, 5, 3, 2, Type.Weapon, Type.Shield);
    public static Item uncommonAxe = new Item("Iron Axe", 50, 10, 8, 0, 1, Type.Weapon);
    public static Item uncommonDagger = new Item("Iron Dagger", 50, 10, 4, 0, 3, Type.Weapon);
    public static Item uncommonShield = new Item("Iron Shield", 50, 10, 0, 4, 0, Type.Shield);
    public static Item rareSword = new Item("Crystal Blade", 0, 12, 9, 5, 3, Type.Weapon, Type.Shield);
    public static Item rareAxe = new Item("Monstrous Axe", 0, 12, 14, 0, 2, Type.Weapon);
    public static Item rareDagger = new Item("Bejeweled Dirk", 0, 12, 7, 0, 4, Type.Weapon);
    public static Item rareShield = new Item("Dragon Shield", 0, 12, 0, 8, 0, Type.Shield);

    public static Item[] commonEquipmentDrops = new Item[]
    {
        sword,
        axe,
        dagger,
        shield,
        uncommonSword,
        uncommonAxe,
        uncommonDagger,
        uncommonShield
    };

    public static Item[] basicEquipment = new Item[]
    {
        sword,
        axe,
        dagger
    };

    public static Item[] rareEquipment = new Item[]
    {
        rareSword,
        rareAxe,
        rareDagger,
        rareShield
    };

    public static Item key = new Item("Key", 20, 0, 0, 0, 0, Type.Key);
    public static Item gold = new Item("Gold", 1, 0, 0, 0, 0, Type.Currency);
    public static Item healthPotion = new Item("Health Potion", 30, 0, 0, 0, 0, Type.Consumable);
    public static Item manaPotion = new Item("Mana Potion", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item strengthMushroom = new Item("Strength Mushroom", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item defenseMushroom = new Item("Defense Mushroom", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item speedMushroom = new Item("Speed Mushroom", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item net = new Item("Net", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item redBerry = new Item("Red Berry", 0, 0, 0, 0, 0, Type.Consumable);
    public static Item blueBerry = new Item("Blue Berry", 0, 0, 0, 0, 0, Type.Consumable);

    public static Item scrollChill = new Item("Chill Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollAcidBlast = new Item("Acid Blast Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollPoisonCloud = new Item("Poison Cloud Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollFireball = new Item("Fireball Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollDivineShield = new Item("Divine Shield Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollEnchantWeapon = new Item("Enchant Weapon Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollHaste = new Item("Haste Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);
    public static Item scrollHeal = new Item("Heal Scroll", 0, 0, 0, 0, 0, Type.Consumable, Type.Skill);

    public static Item ring = new Item("Ring", 100, 0, 0, 0, 0, Type.Treasure);
    public static Item armband = new Item("Armband", 100, 0, 0, 0, 0, Type.Treasure);
    public static Item necklace = new Item("Necklace", 100, 0, 0, 0, 0, Type.Treasure);
    public static Item charm = new Item("Charm", 100, 0, 0, 0, 0, Type.Treasure);

    public static Item[] treasures = new Item[]
    {
        ring,
        armband,
        necklace,
        charm
    };

    public static Item[] merchantWares = new Item[]
    {
        key,
        healthPotion,
        /*
        uncommonSword,
        uncommonAxe,
        uncommonDagger,
        uncommonShield,
        */
        ring,
        armband,
        necklace,
        charm
    };

    public static Item[] questRewards = new Item[]
    {
        scrollChill,
        scrollAcidBlast,
        scrollPoisonCloud,
        scrollFireball,
        scrollDivineShield,
        scrollEnchantWeapon,
        scrollHaste,
        scrollHeal,
        uncommonSword,
        uncommonAxe,
        uncommonDagger,
        uncommonShield,
        rareSword,
        rareAxe,
        rareDagger,
        rareShield
    };

    public static Item[] consumables = new Item[]
    {
        healthPotion,
        strengthMushroom,
        defenseMushroom,
        speedMushroom,
        net
    };

    public static Item[] mushrooms = new Item[]
    {
        strengthMushroom,
        defenseMushroom,
        speedMushroom
    };

    public static Item[] berries = new Item[]
    {
        redBerry,
        blueBerry
    };

    public static Item skillChill = new Item("Chill", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillAcidBlast = new Item("Acid Blast", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillPoisonCloud = new Item("Poison Cloud", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillFireball = new Item("Fireball", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillDivineShield = new Item("Divine Shield", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillEnchantWeapon = new Item("Enchant Weapon", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillHaste = new Item("Haste", 0, 0, 0, 0, 0, Type.Skill);
    public static Item skillHeal = new Item("Heal", 0, 0, 0, 0, 0, Type.Skill);

    public static Item[] skills = new Item[]
    {
        skillChill,
        skillAcidBlast,
        skillPoisonCloud,
        skillFireball,
        skillDivineShield,
        skillEnchantWeapon,
        skillHaste,
        skillHeal
    };
}
