using System.Collections.Generic;
using UnityEngine;

public class Companion
{
    public readonly Gender gender;

    public string name;
    public Sprite body;
    public Sprite hair;
    public Sprite outfit;

    public Sprite normalFace;
    public Sprite happyFace;
    public Sprite sadFace;

    public int attack;
    public int defense;
    public int speed;

    public int hearts;

    public int heartLevel
    {
        get
        {
            int level = 1;
            while (level <= HeartUtility.maxHeartLevel)
            {
                if (hearts < HeartUtility.HeartsRequired(level + 1))
                {
                    break;
                }

                ++level;
            }

            return level;
        }
    }

    public List<Item> skills = new List<Item>();

    public Companion(Gender gender)
    {
        this.gender = gender;
    }
}
