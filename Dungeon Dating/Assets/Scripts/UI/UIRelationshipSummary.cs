using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRelationshipSummary : MonoBehaviour
{
    public UICompanionPortrait portrait;
    public Text speechText;
    public UIProgressBar relationshipProgressBar;
    public Text relationshipLevelLabel;
    public Text relationshipMaxLabel;
    public GameObject giftSection;
    public GameObject progressBarSection;
    public GameObject verdictSection;

    public List<Item> gifts;

    private Companion companion;
    private string partingSpeech;

    private int heartsToGrant;

    public void OnTapReject()
    {
        gameObject.SetActive(false);
        AdventureManager.instance.ShowFinancialSummary();
    }

    public void OnTapAccept()
    {
        // TODO: show notification that you will meet this companion again.
        Player.instance.companionsToMeetAgain.Add(companion);
        gameObject.SetActive(false);
        AdventureManager.instance.ShowFinancialSummary();
    }

    public void Show(Companion companion)
    {
        this.companion = companion;

        heartsToGrant = 0;
        speechText.text = "Hey, that was fun! Thanks for running this dungeon with me.";
        partingSpeech = null;

        portrait.companion = companion;
        giftSection.SetActive(false);
        progressBarSection.SetActive(true);
        verdictSection.SetActive(false);

        gameObject.SetActive(true);
    }

    public void FillHearts(int numHeartsEarned)
    {
        heartsToGrant = numHeartsEarned;

        gifts = new List<Item>();
        partingSpeech = "Okay goodbye!";
    }

    private void FixedUpdate()
    {
        if (heartsToGrant > 0)
        {
            companion.hearts++;
            --heartsToGrant;
        }

        int progress = companion.hearts - HeartUtility.HeartsRequired(companion.heartLevel);
        int goal = HeartUtility.HeartsRequired(companion.heartLevel + 1) - HeartUtility.HeartsRequired(companion.heartLevel);
        relationshipProgressBar.Set(progress, goal);
        relationshipLevelLabel.text = companion.heartLevel.ToString();
        if (companion.heartLevel == HeartUtility.maxHeartLevel)
        {
            relationshipLevelLabel.color = relationshipMaxLabel.color;
            relationshipMaxLabel.gameObject.SetActive(true);
        }
        else
        {
            relationshipLevelLabel.color = Color.white;
            relationshipMaxLabel.gameObject.SetActive(false);
        }

        giftSection.SetActive(gifts != null && heartsToGrant == 0);
        verdictSection.SetActive(gifts != null && heartsToGrant == 0);

        if ((!string.IsNullOrEmpty(partingSpeech)) && (heartsToGrant == 0))
        {
            speechText.text = partingSpeech;
        }
    }
}
