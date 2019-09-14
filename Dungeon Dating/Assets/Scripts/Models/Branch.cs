using System.Collections.Generic;
using UnityEngine;

public class Branch
{
    public List<Situation> situations = new List<Situation>();

    public Situation currentSituation
    {
        get
        {
            if (situationIndex < situations.Count)
            {
                return situations[situationIndex];
            }
            else
            {
                return null;
            }
        }
    }

    public int situationIndex { get; private set; }

    public Branch()
    {
        situationIndex = 0;
    }

    public void Advance()
    {
        situationIndex++;

        AdventureManager.instance.playerFighter.ResetMods();
    }
}
