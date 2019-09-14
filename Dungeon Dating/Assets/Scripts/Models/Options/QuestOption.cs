public abstract class QuestOption : Option
{
    protected Quest quest;

    public QuestOption(Quest quest, string title) : base(title)
    {
        this.quest = quest;
    }
}
