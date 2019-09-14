using System;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public static AdventureManager instance;

    public UIGenderChooser genderChooser;
    public UICompanionChooser companionChooser;
    public GameObject adventureView;
    public UIEnemyView enemyView;
    public UIChestView chestView;
    public UIQuestView questView;
    public UIExploreView exploreView;
    public UIMerchantView merchantView;
    public GameObject combatOptionSection;
    public Transform combatOptionContainer;
    public GameObject buyOptionSection;
    public Transform buyOptionContainer;
    public GameObject questOptionSection;
    public Transform questOptionContainer;
    public GameObject openOptionSection;
    public Transform openOptionContainer;
    public GameObject takeOptionSection;
    public Transform takeOptionContainer;
    public GameObject exploreOptionSection;
    public Transform exploreOptionContainer;
    public UICompanionComment companionComment;
    public UIRelationshipSummary relationshipSummary;
    public UIFinancialSummary financialSummary;
    public UIHeartContainer heartContainer;

    public GameObject dungeonChooser;

    public GameObject optionButtonPrefab;

    public Dungeon dungeon { get; private set; }
    public Fighter playerFighter;
    public Companion companion { get; private set; }

    [HideInInspector]
    public Branch branch;

    private float secondsUntilCombatStateAdvance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        genderChooser.gameObject.SetActive(!Player.instance.gender.HasValue);
        companionChooser.gameObject.SetActive(companion == null);
        dungeonChooser.SetActive(dungeon == null);
        adventureView.SetActive(dungeon != null && companion != null);

        if (dungeon != null)
        {
            if (branch != null)
            {
                if (branch.currentSituation != null)
                {
                    if (secondsUntilCombatStateAdvance <= 0.0f)
                    {
                        var optionsByType = branch.currentSituation.GetOptions();
                        CreateOptionButtons(optionsByType, typeof(CombatOption), combatOptionSection, combatOptionContainer);
                        CreateOptionButtons(optionsByType, typeof(BuyOption), buyOptionSection, buyOptionContainer);
                        CreateOptionButtons(optionsByType, typeof(QuestOption), questOptionSection, questOptionContainer);
                        CreateOptionButtons(optionsByType, typeof(OpenOption), openOptionSection, openOptionContainer);
                        CreateOptionButtons(optionsByType, typeof(TakeOption), takeOptionSection, takeOptionContainer);
                        CreateOptionButtons(optionsByType, typeof(MoveOption), exploreOptionSection, exploreOptionContainer);
                    }

                    enemyView.gameObject.SetActive(branch.currentSituation.enemy != null);
                    chestView.gameObject.SetActive(branch.currentSituation.chest != null);
                    questView.gameObject.SetActive(branch.currentSituation.enemy == null && branch.currentSituation.quest != null);
                    exploreView.gameObject.SetActive(branch.currentSituation.branch != null);
                    merchantView.gameObject.SetActive(branch.currentSituation.merchant != null);

                    if (branch.currentSituation.enemy != null)
                    {
                        enemyView.enemy = branch.currentSituation.enemy;
                    }
                    else if (branch.currentSituation.chest != null)
                    {
                        chestView.chest = branch.currentSituation.chest;
                    }
                    else if (branch.currentSituation.quest != null)
                    {
                        questView.quest = branch.currentSituation.quest;
                    }
                    else if (branch.currentSituation.merchant != null)
                    {
                        merchantView.merchant = branch.currentSituation.merchant;
                    }
                }
                else
                {
                    if (branch == dungeon.mainBranch)
                    {
                        // we're finished with the dungeon.
                        Clear();
                    }
                    else
                    {
                        branch = dungeon.mainBranch;
                        branch.Advance();
                    }

                    Refresh();
                }
            }
            else
            {
                dungeon = null;
                return;
            }
        }
    }

    private void CreateOptionButtons(Dictionary<Type, List<Option>> optionsByType, Type optionType, GameObject optionSection, Transform optionContainer)
    {
        for (int childIndex = 0; childIndex < optionContainer.childCount; ++childIndex)
        {
            Destroy(optionContainer.GetChild(childIndex).gameObject);
        }

        List<Option> options;
        if ((optionsByType.TryGetValue(optionType, out options)) && (options.Count > 0))
        {
            foreach (var option in options)
            {
                var optionButtonGameObject = Instantiate(optionButtonPrefab);
                optionButtonGameObject.GetComponent<UIOptionButton>().option = option;
                optionButtonGameObject.transform.SetParent(optionContainer, false);
            }

            optionSection.SetActive(true);
        }
        else
        {
            optionSection.SetActive(false);
        }
    }

    public void AdvanceCombatState()
    {
        combatOptionSection.SetActive(false);
        secondsUntilCombatStateAdvance = 1.5f;
    }

    private void FixedUpdate()
    {
        if (secondsUntilCombatStateAdvance > 0.0f)
        {
            secondsUntilCombatStateAdvance -= Time.fixedDeltaTime;

            if (secondsUntilCombatStateAdvance <= 0.0f)
            {
                combatOptionSection.SetActive(true);
                branch.currentSituation.AdvanceCombatState();
                Refresh();
            }
        }
    }

    public void Clear()
    {
        dungeon = null;
        companion = null;
        branch = null;
        heartContainer.hearts = 0;

        Refresh();
    }

    public void StartDungeon(Dungeon dungeon)
    {
        this.dungeon = dungeon;
        dungeon.GenerateSituations();
        playerFighter = new Fighter(Player.instance.character);
        branch = dungeon.mainBranch;
        Refresh();

        CompanionComment("What a pleasant location for a date!");
    }

    public void SelectCompanion(Companion companion)
    {
        this.companion = companion;
        Refresh();
    }

    public void ShowRelationshipSummary()
    {
        relationshipSummary.Show(companion);
        heartContainer.isTappable = true;
    }

    public void ShowFinancialSummary()
    {
        financialSummary.Show();
    }

    public void AddHearts(int hearts, string message)
    {
        heartContainer.hearts += hearts;
        CompanionComment(message);
    }

    public void CompanionComment(string message)
    {
        companionComment.Show(companion, message);
    }
}
