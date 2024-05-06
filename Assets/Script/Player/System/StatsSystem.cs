using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsSystem
{ // Khoi dau voi 60 diem 
    public int Vitality;
    public int Mind;
    public int Endurance;
    public int Strength;
    public int Dexterity;
    public int Intelligence;

    public void AddVitality()
    {
        Vitality++;
        if (Vitality >= 100)
        {
            Vitality = 99;
        }

    }
    public void Subtraction()
    {
        Vitality--;
        if (Vitality <= 0)
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
}
