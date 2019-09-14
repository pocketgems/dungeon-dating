using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeartUtility
{
    public const int maxHeartLevel = 5;

    public static int HeartsRequired(int heartLevel)
    {
        if (heartLevel <= 1)
        {
            return 0;
        }
        else if (heartLevel == 2)
        {
            return 10;
        }
        else
        {
            return 20 + 10 * (heartLevel - 3);
        }
    }
}
