using System;

public static class SpeedUtility
{
    public static float SuccessChance(int mySpeed, int theirSpeed)
    {
        int difference = mySpeed - theirSpeed;
        if (difference > 2)
        {
            return 1;
        }
        else
        {
            return 0.5f + 0.5f * difference / (Math.Abs(difference) + 1);
        }
    }

    public static bool Success(int mySpeed, int theirSpeed)
    {
        return (UnityEngine.Random.Range(0, 1.0f) <= SuccessChance(mySpeed, theirSpeed));
    }
}
