using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static int RisaNum;
    public static int RecycleStage1;
    public static int RecycleStage2;
    public static bool bStage1;

    public static void Init()
    {
        RisaNum = 1;
        RecycleStage1 = 0;
        RecycleStage2 = 0;
    }

    public static void SaveRecycle(int value)
    {
        if(bStage1)
        {
            RecycleStage1 = value;
        }
        else
        {
            RecycleStage2 = value;
        }
    }
}
