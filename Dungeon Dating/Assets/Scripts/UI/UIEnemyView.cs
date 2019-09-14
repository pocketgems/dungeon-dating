using UnityEngine;
using UnityEngine.UI;

public class UIEnemyView : MonoBehaviour
{
    public Text nameLabel;
    public Image image;
    public UIProgressBar healthBar;
    public Text attackLabel;
    public Text defenseLabel;
    public Text speedLabel;

    private Fighter _enemy;
    public Fighter enemy
    {
        get
        {
            return _enemy;
        }

        set
        {
            _enemy = value;

            if (value != null)
            {
                nameLabel.text = value.character.characterName;
                image.sprite = value.character.sprite;
                image.preserveAspect = true;
            }
            else
            {
                nameLabel.text = "";
                image.sprite = null;
            }
        }
    }

    public void FixedUpdate()
    {
        if (enemy != null)
        {
            attackLabel.text = enemy.attack.ToString();
            defenseLabel.text = enemy.defense.ToString();
            speedLabel.text = enemy.speed.ToString();
            healthBar.Set(enemy.health, enemy.character.maxHealth);
        }
    }
}
