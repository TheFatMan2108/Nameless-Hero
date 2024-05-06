using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{
    public int level;
    public float exp;
    public int pointStats;
    public float expNextLevel;

    public LevelSystem() 
    {
        level = 1;
        exp = 0f;
        expNextLevel = 100f;
    }

    public void AddExp(float exp)
    {
        this.exp += exp;
        if(this.exp >= expNextLevel)
        {
            this.exp -= expNextLevel;
            pointStats++;
            
        }
    }
}
