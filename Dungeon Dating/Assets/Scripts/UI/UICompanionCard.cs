using UnityEngine;
using UnityEngine.UI;

public class UICompanionCard : MonoBehaviour
{
    public Image body;
    public Image face;
    public Image outfit;
    public Image hair;
    public Text nameLabel;
    public Text profile;

    public GameObject relationshipSection;
    public UIProgressBar heartProgressBar;
    public Text heartLevelLabel;
    public Text heartMaxLabel;

    private Companion _companion;
    public Companion companion
    {
        set
        {
            _companion = value;

            body.sprite = value.body;
            face.sprite = value.normalFace;
            outfit.sprite = value.outfit;
            hair.sprite = value.hair;
            nameLabel.text = value.name;
            profile.text = "Profile goes here.";

            if (value.hearts == 0)
            {
                relationshipSection.SetActive(false);
            }
            else
            {
                relationshipSection.SetActive(true);

                int progress = value.hearts - HeartUtility.HeartsRequired(value.heartLevel);
                int goal = HeartUtility.HeartsRequired(value.heartLevel + 1) - HeartUtility.HeartsRequired(value.heartLevel);

                heartProgressBar.Set(progress, goal);
                heartLevelLabel.text = value.heartLevel.ToString();
                if (value.heartLevel == HeartUtility.maxHeartLevel)
                {
                    heartLevelLabel.color = heartMaxLabel.color;
                    heartMaxLabel.gameObject.SetActive(true);
                }
                else
                {
                    heartLevelLabel.color = Color.white;
                    heartMaxLabel.gameObject.SetActive(false);
                }
            }
        }

        get
        {
            return _companion;
        }
    }
}
