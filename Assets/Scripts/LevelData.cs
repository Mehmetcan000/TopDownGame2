using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public static int currentLevel = 1;
    public static int maxLevel = 2;

    public static  string GetCurrentLevelName(int level)
    {
       switch(level)
        {
            case 1:
                return "SampleScene_1";
            case 2:
                return "SampleScene_2";

            default:
                return "MainMenu";
        }

    }

}
