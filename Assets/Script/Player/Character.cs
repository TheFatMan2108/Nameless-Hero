using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character:MonoBehaviour
{
    public string namePlayer;
    //class
    public ClassType classType;
    //level
    public int level;
    public float exp;
    public int pointStats;
    public float expNextLevel;
    // stats
    StatsSystem stats = new StatsSystem();
    public int Vitality;
    public int Mind;
    public int Endurance;
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public void CreatedCharacter(string name, ClassType classType)
    {
        namePlayer = name;
        ChoiceClass(classType);
        LevelBegin();
    }
    // class
    public void ChoiceClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Warrior:
                Warrior();
                break;
            case ClassType.Mage:
                Mage();
                break;
            case ClassType.Rogue:
                Rogue();
                break;
            case ClassType.Wretch:
                Wretch();
                break;
            default:
                Warrior();
                break;
        }
        classType = type;
    }
    private void Warrior()
    {
        Vitality = 15;
        Mind = 5;
        Endurance = 15;
        Strength = 15;
        Dexterity = 5;
        Intelligence = 5;
    }
    private void Mage()
    {
        Vitality = 10;
        Mind = 15;
        Endurance = 10;
        Strength = 5;
        Dexterity = 5;
        Intelligence = 15;
       
    }
    private void Rogue()
    {
        Vitality = 10;
        Mind = 5;
        Endurance = 15;
        Strength = 5;
        Dexterity = 20;
        Intelligence = 5;
    }
    private void Wretch()
    {
        Vitality = 10;
        Mind = 10;
        Endurance = 10;
        Strength = 10;
        Dexterity = 10;
        Intelligence = 10;
    }
    public void ResetStats()
    {
        for (int i = 0; i < Enum.GetNames(typeof(ClassType)).Length; i++)
        {
            if (i==(int)classType)
            {
                ChoiceClass((ClassType)i);
                return;
            }
        }

    }
    //

    // Stast
    public void AddVitality()
    {
        Vitality++;
        if(Vitality >= 100)
        {
            Vitality = 99;
        }

    }
    public void Subtraction()
    {
        Vitality--;
        if(Vitality <= 0)
        {
            Vitality = 0;
        }
    }
    public void AddMind()
    {
        Mind++;
        if (Mind >= 100)
        {
            Mind = 99;
        }
    }
    public void Subtraction2()
    {
        Mind--;
        if (Mind <= 0)
        {
            Mind = 0;
        }
    }
    public void AddEndurance()
    {
        Endurance++;
        if (Endurance >= 100)
        {
            Endurance = 99;
        }
    }
    public void SuntractionEndurance()
    {
        Endurance--;
        if (Endurance <= 0)
        {
            Endurance = 0;
        }
    }
    public void AddStrength()
    {
        Strength++;
        if (Strength >= 100)
        {
            Strength = 99;
        }
    }
    public void SubtractionStrength()
    {
        Strength--;
        if (Strength <= 0)
        {
            Strength = 0;
        }
    }
    public void AddDexterity()
    {
        Dexterity++;
        if (Dexterity >= 100)
        {
            Dexterity = 99;
        }
    }
    public void SubtractionDexterity()
    {
        Dexterity--;
        if (Dexterity <= 0)
        {
            Dexterity = 0;
        }
    }
    public void AddIntelligence()
    {
        Intelligence++;
        if (Intelligence >= 100)
        {
            Intelligence = 99;
        }
    }
    public void SubtractionIntelligence()
    {
        Intelligence--;
    }
    //

    //level
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
        }
    }

    public enum ClassType
    {
         Warrior, Mage, Rogue,Wretch
    }
}
