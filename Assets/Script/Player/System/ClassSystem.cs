using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSystem 
{
    public string nameClass;
    public StatsSystem stats;
    public string[] classSelected = { "Warrior", "Mage", "Rogue ", "Wretch" };

    public StatsSystem ChoiceClass(int index)
    {
        switch (index)
        {
            case 0:
               return Warrior();
            case 1:
                return Mage();
            case 2:
                return Rogue();
            case 3:
                return Wretch();
            default: return Warrior();
        }
    }

    private StatsSystem Warrior()
    {
        nameClass = classSelected[0];
        stats = new StatsSystem();
        stats.Vitality = 15;
        stats.Mind = 5;
        stats.Endurance = 15;
        stats.Strength = 15;
        stats.Dexterity = 5;
        stats.Intelligence = 5;
        return stats;
    }
    private StatsSystem Mage()
    {
        nameClass = classSelected[1];
        stats = new StatsSystem();
        stats.Vitality = 10;
        stats.Mind = 15;
        stats.Endurance = 10;
        stats.Strength = 5;
        stats.Dexterity = 5;
        stats.Intelligence = 15;
        return stats;
    }
    private StatsSystem Rogue()
    {
        nameClass = classSelected[2];
        stats = new StatsSystem();
        stats.Vitality = 10;
        stats.Mind = 5;
        stats.Endurance = 15;
        stats.Strength = 5;
        stats.Dexterity = 20;
        stats.Intelligence = 5;
        return stats;
    }
    private StatsSystem Wretch()
    {
        nameClass = classSelected[3];
        stats = new StatsSystem();
        stats.Vitality = 10;
        stats.Mind = 10;
        stats.Endurance = 10;
        stats.Strength = 10;
        stats.Dexterity = 10;
        stats.Intelligence = 10;
        return stats;
    }
}
