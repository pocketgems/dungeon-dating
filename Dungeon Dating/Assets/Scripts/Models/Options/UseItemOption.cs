using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemOption : CombatOption
{
    private ItemQuantity itemQuantity;

    public UseItemOption(ItemQuantity itemQuantity) : base(itemQuantity.item.name)
    {
        this.itemQuantity = itemQuantity;
    }

    public override void Execute()
    {
        var item = itemQuantity.item;
        var combatState = AdventureManager.instance.branch.currentSituation.combatState;
        var enemy = AdventureManager.instance.branch.currentSituation.enemy;
        if (itemQuantity.quantity > 0)
        {
            if (combatState == Situation.CombatState.Attack)
            {
                if (item.types.Contains(Item.Type.Weapon))
                {
                    if (itemQuantity.durabilityRemaining > 0)
                    {
                        if (SpeedUtility.Success(AdventureManager.instance.playerFighter.speed + item.speed, enemy.speed))
                        {
                            Player.instance.LoseDurability(item);
                            enemy.health -= AdventureManager.instance.playerFighter.attack + item.attack;
                        }
                    }
                }
                else if (item.types.Contains(Item.Type.Consumable))
                {
                    if (Player.instance.TryRemoveItem(new ItemQuantity(item, 1)))
                    {
                        if (item == Item.healthPotion)
                        {
                            AdventureManager.instance.playerFighter.health += Player.instance.character.maxHealth / 2;
                        }
                        else if (item == Item.manaPotion)
                        {
                            AdventureManager.instance.playerFighter.mana = Player.instance.character.maxMana;
                        }
                        else if (item == Item.strengthMushroom)
                        {
                            AdventureManager.instance.playerFighter.attackMod += 1;
                        }
                        else if (item == Item.defenseMushroom)
                        {
                            AdventureManager.instance.playerFighter.defenseMod += 1;
                        }
                        else if (item == Item.speedMushroom)
                        {
                            AdventureManager.instance.playerFighter.speedMod += 1;
                        }
                        else if (item == Item.net)
                        {
                            AdventureManager.instance.branch.currentSituation.enemy.speedMod = -2;
                        }
                        else if (item == Item.redBerry)
                        {
                            AdventureManager.instance.playerFighter.health += 5;
                        }
                        else if (item == Item.blueBerry)
                        {
                            AdventureManager.instance.playerFighter.mana += 2;
                        }
                        else if (item.types.Contains(Item.Type.Skill))
                        {
                            SkillUtility.UseSkill(item, AdventureManager.instance.playerFighter.attack, AdventureManager.instance.playerFighter.defense, AdventureManager.instance.playerFighter.speed);
                        }
                    }
                }
                else if (item.types.Contains(Item.Type.Skill))
                {
                    SkillUtility.UseSkill(item, AdventureManager.instance.playerFighter.attack, AdventureManager.instance.playerFighter.defense, AdventureManager.instance.playerFighter.speed);
                }

                AdventureManager.instance.AdvanceCombatState();
            }
            else if (combatState == Situation.CombatState.Defend)
            {
                if (item.types.Contains(Item.Type.Shield))
                {
                    if (itemQuantity.durabilityRemaining > 0)
                    {
                        Player.instance.LoseDurability(item);
                        int damage = enemy.attack - item.defense;
                        if (damage < 0)
                        {
                            damage = 0;
                        }

                        AdventureManager.instance.playerFighter.health -= damage;
                    }
                }

                AdventureManager.instance.AdvanceCombatState();
            }
        }
    }
}
