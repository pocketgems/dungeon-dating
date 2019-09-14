using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UICompanionChooser : MonoBehaviour
{
    public UIProgressBar energyBar;
    public UICompanionCard companionCardPrefab;
    public Transform companionCardAnchor;
    public Text cardsRemainingLabel;
    public GameObject searchForMoreCompanionsButton;
    public GameObject verdictSection;
    public UIMarriageView marriageView;

    public GameObject acceptButton;
    public GameObject marryButton;

    private const int numCompanionsGeneratedPerRoll = 5;
    private Stack<UICompanionCard> companionCards = new Stack<UICompanionCard>();
    private UICompanionCard currentCompanionCard;

    public void Clear()
    {
        while (currentCompanionCard != null)
        {
            AdvanceToNextCompanionCard();
        }
    }

    public void OnTapFindMoreCompanions()
    {
        if (Player.instance.energy > 0)
        {
            --Player.instance.energy;

            var oldCompanions = Player.instance.companionsToMeetAgain.ToList();

            Gender companionGender = Player.instance.gender == Gender.Male ? Gender.Female : Gender.Male;
            for (int companionCounter = 0; companionCounter < numCompanionsGeneratedPerRoll; ++companionCounter)
            {
                Companion companion;
                if (oldCompanions.Count > 0)
                {
                    companion = oldCompanions[0];
                    oldCompanions.RemoveAt(0);
                }
                else
                {
                    companion = CompanionGenerator.instance.CreateCompanion(companionGender);
                }

                var companionCard = Instantiate(companionCardPrefab);
                companionCard.companion = companion;
                companionCard.transform.SetParent(companionCardAnchor, false);
                companionCards.Push(companionCard);
            }

            if (currentCompanionCard == null)
            {
                currentCompanionCard = companionCards.Pop();
            }

            RefreshCompanionsRemainingLabel();
        }
    }

    public void OnTapAccept()
    {
        if (Player.instance.energy > 0)
        {
            --Player.instance.energy;
            AdventureManager.instance.SelectCompanion(currentCompanionCard.companion);
            AdvanceToNextCompanionCard();
        }
    }

    public void OnTapReject()
    {
        AdvanceToNextCompanionCard();
    }

    public void OnTapMarry()
    {
        marriageView.Show(currentCompanionCard.companion);
    }

    private void AdvanceToNextCompanionCard()
    {
        if (currentCompanionCard != null)
        {
            Destroy(currentCompanionCard.gameObject);
        }

        if (companionCards.Count > 0)
        {
            currentCompanionCard = companionCards.Pop();
        }
        else
        {
            currentCompanionCard = null;
        }

        RefreshCompanionsRemainingLabel();
    }

    private void RefreshCompanionsRemainingLabel()
    {
        int numCompanionsRemaining = 0;

        if (currentCompanionCard != null)
        {
            numCompanionsRemaining++;
        }

        numCompanionsRemaining += companionCards.Count;

        if (numCompanionsRemaining == 0)
        {
            cardsRemainingLabel.text = "No adventurers remaining.";
        }
        else
        {
            cardsRemainingLabel.text = numCompanionsRemaining + " fellow adventurers to choose from.";
        }
    }

    private void Update()
    {
        verdictSection.SetActive(currentCompanionCard != null);
        searchForMoreCompanionsButton.SetActive(currentCompanionCard == null && companionCards.Count == 0);
        energyBar.Set(Player.instance.energy, Player.instance.maxEnergy);

        if (currentCompanionCard != null)
        {
            acceptButton.SetActive(currentCompanionCard.companion.heartLevel < HeartUtility.maxHeartLevel);
            marryButton.SetActive(currentCompanionCard.companion.heartLevel == HeartUtility.maxHeartLevel);
        }
    }
}
