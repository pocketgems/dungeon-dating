using System;

public class CombatMenuOption : CombatOption
{
    Situation.CombatMenuState menuState;

    public CombatMenuOption(Situation.CombatMenuState menuState) : base(menuState == Situation.CombatMenuState.Root ? "Cancel" : Enum.GetName(typeof(Situation.CombatMenuState), menuState))
    {
        this.menuState = menuState;
    }

    public override void Execute()
    {
        AdventureManager.instance.branch.currentSituation.combatMenuState = menuState;
    }
}
