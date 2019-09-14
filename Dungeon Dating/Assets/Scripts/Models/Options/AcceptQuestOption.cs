public class AcceptQuestOption : QuestOption
{
    public AcceptQuestOption(Quest quest) : base(quest, "Accept Quest")
    {
    }

    public override void Execute()
    {
        AdventureManager.instance.branch.currentSituation.enemy = new Fighter(quest.enemy);
    }
}
