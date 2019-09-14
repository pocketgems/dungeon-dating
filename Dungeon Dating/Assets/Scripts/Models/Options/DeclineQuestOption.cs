public class DeclineQuestOption : QuestOption
{
    public DeclineQuestOption(Quest quest) : base(quest, "Decline Quest")
    {
    }

    public override void Execute()
    {
        AdventureManager.instance.branch.Advance();
    }
}
