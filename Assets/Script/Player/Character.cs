using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character 
{
    public string namePlayer;
    //class
    public ClassSystem systemClass = new ClassSystem();
    //level
    public LevelSystem levelSystem = new LevelSystem();
    // stats
    public StatsSystem stats = new StatsSystem();
    public void CreatedCharacter(string name, ClassSystem.ClassType classType)
    {
        namePlayer = name;
        systemClass.ChoiceClass(classType);
        levelSystem.LevelBegin();
        stats = systemClass.stats;
    }
    public void SavePlayer(string idSave)
    {
        string data = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(idSave, data);
    }
    public void UpdateLevel()
    {

    }
   
}
