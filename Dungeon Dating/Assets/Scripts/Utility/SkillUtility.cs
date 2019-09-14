public static class SkillUtility
{
    public static void UseSkill(Item skill, int attack, int defense, int speed)
    {
        var enemy = AdventureManager.instance.branch.currentSituation.enemy;

        if (skill == Item.skillAcidBlast)
        {
            enemy.health -= attack / 3;
            enemy.defenseMod -= 1;
        }
        else if (skill == Item.skillChill)
        {
            enemy.health -= attack / 3;
            enemy.speedMod -= 1;
        }
        else if (skill == Item.skillDivineShield)
        {
            AdventureManager.instance.playerFighter.defenseMod += 1;
        }
        else if (skill == Item.skillEnchantWeapon)
        {
            AdventureManager.instance.playerFighter.attackMod += 1;
        }
        else if (skill == Item.skillFireball)
        {
            enemy.health -= 2 * attack;
        }
        else if (skill == Item.skillHaste)
        {
            AdventureManager.instance.playerFighter.speedMod += 1;
        }
        else if (skill == Item.skillHeal)
        {
            AdventureManager.instance.playerFighter.health += Player.instance.character.maxHealth / 20;
        }
        else if (skill == Item.skillPoisonCloud)
        {
            enemy.health -= attack / 3;
            enemy.attackMod -= 1;
        }
    }
}
