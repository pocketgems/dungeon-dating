using UnityEngine;

public class CompanionGenerator : MonoBehaviour
{
    public static CompanionGenerator instance;

    public Sprite[] bodies;
    public Sprite[] maleHair;
    public Sprite[] maleOutfits;
    public Sprite[] femaleHair;
    public Sprite[] femaleOutfits;

    public Sprite normalFace;
    public Sprite happyFace;
    public Sprite sadFace;

    public string[] maleNames;
    public string[] femaleNames;

    private void Awake()
    {
        instance = this;
    }

    public Companion CreateCompanion(Gender gender)
    {
        Companion companion = new Companion(gender);

        if (gender == Gender.Male)
        {
            companion.name = RandomString(maleNames);
            companion.hair = RandomSprite(maleHair);
            companion.body = RandomSprite(bodies);
            companion.outfit = RandomSprite(maleOutfits);
        }
        else
        {
            companion.name = RandomString(femaleNames);
            companion.hair = RandomSprite(femaleHair);
            companion.body = RandomSprite(bodies);
            companion.outfit = RandomSprite(femaleOutfits);
        }

        companion.normalFace = normalFace;
        companion.happyFace = happyFace;
        companion.sadFace = sadFace;

        companion.attack = 0;
        companion.defense = 0;
        companion.speed = 0;

        var total = Player.instance.character.attack + Player.instance.character.defense + Player.instance.character.speed;
        int pointsToAllocate = Random.Range(total - 10, total + 11);
        for (int point = 0; point < pointsToAllocate; ++point)
        {
            var randomNumber = Random.Range(0.0f, 1.0f);
            if (randomNumber < 0.33f)
            {
                ++companion.attack;
            }
            else if (randomNumber < 0.67f)
            {
                ++companion.defense;
            }
            else
            {
                ++companion.speed;
            }
        }

        if (companion.attack < 3)
        {
            companion.attack = 3;
        }

        companion.skills.Add(Item.skills[Random.Range(0, Item.skills.Length)]);

        return companion;
    }

    private Sprite RandomSprite(Sprite[] sprites)
    {
        return sprites[Random.Range(0, sprites.Length)];
    }

    private string RandomString(string[] strings)
    {
        return strings[Random.Range(0, strings.Length)];
    }
}
