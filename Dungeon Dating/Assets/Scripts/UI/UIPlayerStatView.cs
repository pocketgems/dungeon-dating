using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStatView : MonoBehaviour
{
    public Text attackLabel;
    public Text defenseLabel;
    public Text speedLabel;
    public Text manaLabel;
    public Text goldLabel;

    private void Update()
    {
        if (AdventureManager.instance.playerFighter != null)
        {
            attackLabel.text = AdventureManager.instance.playerFighter.attack.ToString();
            defenseLabel.text = AdventureManager.instance.playerFighter.defense.ToString();
            speedLabel.text = AdventureManager.instance.playerFighter.speed.ToString();
            manaLabel.text = AdventureManager.instance.playerFighter.mana.ToString();
            goldLabel.text = Player.instance.gold.ToString();
        }
    }
}
