using UnityEngine;
using UnityEngine.UI;

public class UIDungeonChoiceButton : MonoBehaviour
{
    public Text nameLabel;

    private Dungeon _dungeon;
    public Dungeon dungeon
    {
        set
        {
            _dungeon = value;

            nameLabel.text = value.name;
        }

        get
        {
            return _dungeon;
        }
    }
    
    public void OnTap()
    {
        AdventureManager.instance.StartDungeon(dungeon);
    }
}
