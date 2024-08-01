using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelSystem
{
    public int level;
    public float exp;
    public int pointStats;
    public float expNextLevel;

    public LevelSystem()
    {
        LevelBegin();
    }

    public void LevelBegin()
    {
        level = 1;
        exp = 0f;
        expNextLevel = 100f;
    }
    public void AddExp(float exp)
    {
        this.exp += exp;
        while (this.exp >= expNextLevel)
        {
            this.exp -= expNextLevel;
            pointStats++;
            level++;
            expNextLevel = (float)(500f * Math.Pow(level, 2) - (500 * level));
            PlayerManager.Instance.player.SetFloatingText("Level Up").fontSize=15f;
            PlayerManager.Instance.player.levelUp();
        }
        DataPersistenceManager.instance.gameData.levelSystem = this;
    }
}
