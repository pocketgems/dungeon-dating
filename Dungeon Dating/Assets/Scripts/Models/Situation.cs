using System;
using System.Collections.Generic;

public class Situation
{
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
                combatState = CombatState.Attack;
            }
            else
            {
                combatState = CombatState.None;
            }
        }
    }

    public Chest chest;
    public List<ItemQuantity> items = new List<ItemQuantity>();
    public Branch branch;
    public Quest quest;
    public Merchant merchant;
    public bool isFinalSituation;

    private Dictionary<Type, List<Option>> optionsByType = new Dictionary<Type, List<Option>>();

    public enum CombatMenuState
    {
        Root,
        Attack,
        Magic,
        Use
    }

    public CombatMenuState combatMenuState = CombatMenuState.Root;

    public enum CombatState
    {
        None,
        Attack,
        Companion,
        Defend,
    }

    public CombatState combatState { get; private set; }

    public void AdvanceCombatState()
    {
        combatMenuState = CombatMenuState.Root;

        if (combatState == CombatState.Attack)
        {
            if (enemy.health > 0)
            {
                combatState = CombatState.Defend;
            }
            else
            {
                DropLoot();
                AdventureManager.instance.AddHearts(3, "You defeated it! Great job!");
                combatState = CombatState.None;
            }
        }
        else if (combatState == CombatState.Defend)
        {
            if (AdventureManager.instance.playerFighter.health > 0)
            {
                combatState = CombatState.Companion;

                var companion = AdventureManager.instance.companion;
                if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.7f)
                {
                    AdventureManager.instance.branch.currentSituation.enemy.health -= companion.attack;
                    AdventureManager.instance.CompanionComment("Take this!");
                }
                else
                {
                    var randomSkill = companion.skills[UnityEngine.Random.Range(0, companion.skills.Count)];
                    AdventureManager.instance.CompanionComment("Let me help. " + randomSkill.name + "!");
                    SkillUtility.UseSkill(randomSkill, companion.attack, companion.defense, companion.speed);
                }

                AdventureManager.instance.AdvanceCombatState();
            }
            else
            {
                AdventureManager.instance.CompanionComment("Oh no, are you okay? Get up!");
                combatState = CombatState.None;

                // TODO: Lose!
            }
        }
        else if (combatState == CombatState.Companion)
        {
            if (enemy.health > 0)
            {
                combatState = CombatState.Attack;
            }
            else
            {
                DropLoot();
                AdventureManager.instance.AddHearts(3, "Couldn't have done it without you!");
                combatState = CombatState.None;
            }
        }
    }

    private void DropLoot()
    {
        if (quest == null)
        {
            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.2f)
            {
                items.Add(new ItemQuantity(Item.key, 1));
            }
            else
            {
                items.Add(new ItemQuantity(Item.gold, UnityEngine.Random.Range(10, 30)));
            }
        }
        else
        {
            items.Add(quest.reward);
            quest = null;
        }
    }

    public Dictionary<Type, List<Option>> GetOptions()
    {
        optionsByType.Clear();
        optionsByType[typeof(CombatOption)] = new List<Option>();
        optionsByType[typeof(OpenOption)] = new List<Option>();
        optionsByType[typeof(TakeOption)] = new List<Option>();
        optionsByType[typeof(MoveOption)] = new List<Option>();
        optionsByType[typeof(QuestOption)] = new List<Option>();
        optionsByType[typeof(BuyOption)] = new List<Option>();

        if ((enemy != null) && (enemy.health > 0))
        {
            if (combatState == CombatState.Attack)
            {
                if (combatMenuState == CombatMenuState.Root)
                {
                    optionsByType[typeof(CombatOption)].Add(new CombatMenuOption(CombatMenuState.Attack));
                    optionsByType[typeof(CombatOption)].Add(new CombatMenuOption(CombatMenuState.Magic));
                    optionsByType[typeof(CombatOption)].Add(new CombatMenuOption(CombatMenuState.Use));

                    if (!enemy.character.boss)
                    {
                        optionsByType[typeof(CombatOption)].Add(new FleeMenuOption());
                    }

                    //optionsByType[typeof(CombatOption)].Add(new KillOption());
                }
                else
                {
                    if (combatMenuState == CombatMenuState.Attack)
                    {
                        foreach (var itemQuantity in Player.instance.ItemsOfType(Item.Type.Weapon))
                        {
                            optionsByType[typeof(CombatOption)].Add(new UseItemOption(itemQuantity));
                        }

                        optionsByType[typeof(CombatOption)].Add(new PunchOption());
                    }
                    else if (combatMenuState == CombatMenuState.Magic)
                    {
                        foreach (var itemQuantity in Player.instance.ItemsOfType(Item.Type.Skill))
                        {
                            if (!itemQuantity.item.types.Contains(Item.Type.Consumable))
                            {
                                optionsByType[typeof(CombatOption)].Add(new UseItemOption(itemQuantity));
                            }
                        }
                    }
                    else if (combatMenuState == CombatMenuState.Use)
                    {
                        foreach (var itemQuantity in Player.instance.ItemsOfType(Item.Type.Consumable))
                        {
                            optionsByType[typeof(CombatOption)].Add(new UseItemOption(itemQuantity));
                        }
                    }

                    optionsByType[typeof(CombatOption)].Add(new CombatMenuOption(CombatMenuState.Root));
                }
            }
            else if (combatState == CombatState.Defend)
            {
                foreach (var itemQuantity in Player.instance.ItemsOfType(Item.Type.Shield))
                {
                    optionsByType[typeof(CombatOption)].Add(new UseItemOption(itemQuantity));
                }

                optionsByType[typeof(CombatOption)].Add(new DodgeOption());
            }
            else if (combatState == CombatState.Companion)
            {
                // nothing.
            }
        }
        else
        {
            if (isFinalSituation)
            {
                optionsByType[typeof(MoveOption)].Add(new FinishOption());
            }
            else
            {
                optionsByType[typeof(MoveOption)].Add(new ProceedOption());
            }

            if (chest != null)
            {
                if ((!chest.key.HasValue) || (Player.instance.CanRemoveItem(chest.key.Value)))
                {
                    optionsByType[typeof(OpenOption)].Add(new OpenOption(chest));
                }
            }

            if (items != null)
            {
                foreach (var item in items)
                {
                    optionsByType[typeof(TakeOption)].Add(new TakeOption(item));
                }
            }

            if (branch != null)
            {
                optionsByType[typeof(MoveOption)].Add(new ExploreOption("Explore", branch));
            }

            if (merchant != null)
            {
                foreach (var item in Item.merchantWares)
                {
                    optionsByType[typeof(BuyOption)].Add(new BuyOption(item));
                }
            }

            if (quest != null)
            {
                optionsByType[typeof(QuestOption)].Add(new DeclineQuestOption(quest));
                optionsByType[typeof(QuestOption)].Add(new AcceptQuestOption(quest));
            }
        }

        return optionsByType;
    }

}
