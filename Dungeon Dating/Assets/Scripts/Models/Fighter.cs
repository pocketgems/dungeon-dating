using System;

public class Fighter
{
    public Character character;

    private int _health;
    public int health
    {
        set
        {
            if (value > 0)
            {
                if (value > character.maxHealth)
                {
                    value = character.maxHealth;
                }
                else
                {
                    _health = value;
                }
            }
            else
            {
                _health = 0;
            }
        }

        get
        {
            return _health;
        }
    }

    public int mana;

    public int attack
    {
        get
        {
            return Math.Max(0, character.attack + attackMod);
        }
    }

    public int defense
    {
        get
        {
            return Math.Max(0, character.defense + defenseMod);
        }
    }

    public int speed
    {
        get
        {
            return Math.Max(0, character.speed + speedMod);
        }
    }

    public int attackMod;
    public int defenseMod;
    public int speedMod;

    public Fighter(Character character)
    {
        this.character = character;

        health = character.maxHealth;
        mana = character.maxMana;
        attackMod = 0;
        defenseMod = 0;
        speedMod = 0;
    }

    public void ResetMods()
    {
        attackMod = 0;
        defenseMod = 0;
        speedMod = 0;
    }
}
