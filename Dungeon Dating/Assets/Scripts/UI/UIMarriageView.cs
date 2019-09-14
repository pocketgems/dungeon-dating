using UnityEngine;
using UnityEngine.UI;

public class UIMarriageView : MonoBehaviour
{
    public UICompanionChooser companionChooser;
    public Text inheritedSkillNameLabel;
    public Text attackLabel;
    public Text defenseLabel;
    public Text speedLabel;
    public Text skillsText;

    public void Show(Companion companion)
    {
        skillsText.text = "You married " + companion.name + " and had one child.\n\nYour child has learned all of your skills, as well as the following skills from " + companion.name + ":";

        var inheritedSkill = companion.skills[0];
        inheritedSkillNameLabel.text = inheritedSkill.name;

        int attack = (Player.instance.character.attack + companion.attack) / 2 + Random.Range(0, 3);
        int defense = (Player.instance.character.defense + companion.defense) / 2 + Random.Range(0, 3);
        int speed = (Player.instance.character.speed + companion.speed) / 2 + Random.Range(0, 3);

        attackLabel.text = attack.ToString();
        defenseLabel.text = defense.ToString();
        speedLabel.text = speed.ToString();

        Player.instance.TryAddItem(new ItemQuantity(inheritedSkill, 1));
        Player.instance.character.attack = attack;
        Player.instance.character.defense = defense;
        Player.instance.character.speed = speed;

        gameObject.SetActive(true);
    }

    public void OnTapContinue()
    {
        companionChooser.Clear();
        Player.instance.energy = Player.instance.maxEnergy;
        gameObject.SetActive(false);
    }
}
