using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public string name;
    public List<Character> enemies = new List<Character>();
    public List<Character> questEnemies = new List<Character>();
    public Character boss;
    public int mainBranchLength;

    private const int minSideBranchLength = 3;
    private const int maxSideBranchLength = 5;

    public Branch mainBranch;

    public void GenerateSituations()
    {
        mainBranch = new Branch();

        for (int situationCounter = 0; situationCounter < mainBranchLength; ++situationCounter)
        {
            var situation = new Situation();

            if (situationCounter == mainBranchLength - 1)
            {
                // Last room. Spawn the boss.
                situation.isFinalSituation = true;
                situation.enemy = new Fighter(boss);
            }
            else if (situationCounter == 0)
            {
                // First room.
                situation.items.Add(new ItemQuantity(Item.basicEquipment[Random.Range(0, Item.basicEquipment.Length)], 1));
                situation.items.Add(new ItemQuantity(Item.healthPotion, 1));
            }
            else if (situationCounter % 5 == 0)
            {
                // merchant
                situation.merchant = new Merchant();
            }
            else if (situationCounter % 3 == 0)
            {
                var sideBranch = new Branch();
                int sideBranchLength = Random.Range(minSideBranchLength, maxSideBranchLength + 1);
                for (int sideSituationCounter = 0; sideSituationCounter < sideBranchLength; ++sideSituationCounter)
                {
                    var sideSituation = new Situation();
                    if ((sideSituationCounter % 2 == 0) && (enemies.Count > 0))
                    {
                        sideSituation.enemy = new Fighter(enemies[Random.Range(0, enemies.Count)]);
                    }
                    else
                    {
                        var randomNumber = Random.Range(0.0f, 1.0f);
                        if (randomNumber < 0.2f)
                        {
                            if (randomNumber < 0.05f)
                            {
                                sideSituation.chest = new EquipmentChest("gold chest", "open it", new ItemQuantity(Item.key, 1), Item.commonEquipmentDrops);
                            }
                            else
                            {
                                sideSituation.chest = new EquipmentChest("silver chest", "open it", new ItemQuantity(Item.key, 1), Item.rareEquipment);
                            }
                        }
                        else if (randomNumber < 0.5f)
                        {
                            var randomConsumable = Item.consumables[Random.Range(0, Item.consumables.Length)];
                            sideSituation.chest = new Chest("wooden crate", "smash it", null, new ItemQuantity(randomConsumable, 1));
                        }
                        else if (randomNumber < 0.8f)
                        {
                            sideSituation.items.Add(new ItemQuantity(Item.mushrooms[Random.Range(0, Item.mushrooms.Length)], Random.Range(2, 4)));
                        }
                        else
                        {
                            sideSituation.chest = new Chest("holy shrine", "make an offering", new ItemQuantity(Item.gold, 50), new ItemQuantity(Item.manaPotion, 1));
                        }
                    }

                    sideBranch.situations.Add(sideSituation);
                }

                situation.branch = sideBranch;
            }
            else
            {
                if ((situationCounter % 2 == 0) && (enemies.Count > 0))
                {
                    situation.enemy = new Fighter(enemies[Random.Range(0, enemies.Count)]);
                }
                else
                {
                    var randomNumber = Random.Range(0.0f, 1.0f);
                    if (randomNumber < 0.2f)
                    {
                        var randomConsumable = Item.consumables[Random.Range(0, Item.consumables.Length)];
                        situation.chest = new Chest("wooden crate", "smash it", null, new ItemQuantity(randomConsumable, 1));
                    }
                    else if (randomNumber < 0.4f)
                    {
                        var randomBerry = Item.berries[Random.Range(0, Item.berries.Length)];
                        situation.chest = new Chest("berry bush", "forage for berries", null, new ItemQuantity(randomBerry, Random.Range(2, 4)));
                    }
                    else
                    {
                        var reward = Item.questRewards[Random.Range(0, Item.questRewards.Length)];
                        situation.quest = new Quest(questEnemies[Random.Range(0, questEnemies.Count)], new ItemQuantity(reward, 1));
                    }
                }
            }

            mainBranch.situations.Add(situation);
        }
    }
}
