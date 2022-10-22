using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIncrease : MonoBehaviour
{
    public static LevelIncrease instance;

    public IDictionary<int, bool> level;
    private void Awake()
    {
        level = new Dictionary<int, bool>();
        instance = this;

        for (int i = 0; i < 4; i++)
        {
            level.Add(i, false);
        }
    }
    public bool LevelCheck(int levelNum)
    {
        if (level[levelNum]) return true;
        else return false;
    }
    public void LevelCase(int score)
    {
        switch (score)
        {
            case 1:
                level[1] = true;
                Debug.Log("Normal");
                break;
            default:
                break;
        }
    }
}
