using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ClassSystem 
{
    public ClassType nameClass;
    public StatsSystem stats = new StatsSystem();

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
            default:
                Warrior();
                break;
        }
        nameClass = type;
    }

    private void Warrior()
    {
        stats = new StatsSystem();
        stats.Vitality = 15;
        stats.Mind = 5;
        stats.Endurance = 15;
        stats.Strength = 15;
        stats.Dexterity = 5;
        stats.Intelligence = 5;

    }
    private void Mage()
    {
      
        stats = new StatsSystem();
        stats.Vitality = 10;
        stats.Mind = 15;
        stats.Endurance = 10;
        stats.Strength = 5;
        stats.Dexterity = 5;
        stats.Intelligence = 15;
    }
    private void Rogue()
    {
        stats = new StatsSystem();
        stats.Vitality = 10;
        stats.Mind = 5;
        stats.Endurance = 15;
        stats.Strength = 5;
        stats.Dexterity = 20;
        stats.Intelligence = 5;
    }

    public enum ClassType
    {
        Warrior, Mage, Rogue
    }
}
