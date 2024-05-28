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
        stats.Vitality.SetDefaulValue( 15);
        stats.Mind.SetDefaulValue(5);
        stats.Endurance.SetDefaulValue(15);
        stats.Strength.SetDefaulValue(15);
        stats.Dexterity.SetDefaulValue(5);
        stats.Intelligence.SetDefaulValue(5);

    }
    private void Mage()
    {
        stats = new StatsSystem();
        stats.Vitality.SetDefaulValue(10);
        stats.Mind.SetDefaulValue(15);
        stats.Endurance.SetDefaulValue(10);
        stats.Strength.SetDefaulValue(5);
        stats.Dexterity.SetDefaulValue(5);
        stats.Intelligence.SetDefaulValue(15);
    }
    private void Rogue()
    {
        stats = new StatsSystem();
        stats.Vitality.SetDefaulValue(10);
        stats.Mind.SetDefaulValue(5);
        stats.Endurance.SetDefaulValue(15);
        stats.Strength.SetDefaulValue(5);
        stats.Dexterity.SetDefaulValue(20);
        stats.Intelligence.SetDefaulValue(5);
    }

    public enum ClassType
    {
        Warrior, Mage, Rogue
    }
}
