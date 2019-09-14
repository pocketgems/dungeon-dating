using UnityEngine;
using UnityEngine.UI;

public class UIQuestView : MonoBehaviour
{
    public Text situationDescription;
    public Text rewardDescription;

    private Quest _quest;
    public Quest quest
    {
        set
        {
            _quest = value;

            situationDescription.text = "Help! My village is being attacked by a " + quest.enemy.characterName + "!";
            rewardDescription.text = "If you defeat it for us, I'll give you a " + quest.reward.item.name + ".";
        }

        get
        {
            return _quest;
        }
    }
}
