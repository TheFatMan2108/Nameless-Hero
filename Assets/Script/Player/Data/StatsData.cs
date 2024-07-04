using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsData
{
    [Header("Stats")]
    public Stats Vitality;// tang mau 
    public Stats Mind;// tang mana
    public Stats Endurance;//tang the luc
    public Stats Strength;// tang suc manh
    public Stats Dexterity;// tang toc do 
    public Stats Intelligence;// tang sat thuong phep thuat
    [Header("Offensive")]
    public Stats damage; // dame theo vu khi mang theo
    public Stats critChance;// ti le chi mang
    public Stats critPower;// do chi mang
    [Header("Defaul Stats")]
    public Stats maxHealth;// mau toi da
    public Stats maxMana;// mana toi da
    public Stats maxStamina;// stamina toi da
    public Stats armor; // chi so giap - giam sat thuong theo chi so giap hien co
    public Stats magicResistance;// chi so sat thuong phep
    public float curentHeatlth ;
    public float curentMana ;
    public float curentStamina ;
    public StatsData()
    {
        Vitality = new Stats();
        Mind = new Stats();
        Endurance = new Stats();
        Strength = new Stats();
        Dexterity = new Stats();
        Intelligence = new Stats();
        damage = new Stats();
        critChance = new Stats();
        critPower = new Stats();
        maxHealth = new Stats();
        maxMana = new Stats();
        maxStamina = new Stats();
        armor = new Stats();
        magicResistance = new Stats();
        maxHealth.SetDefaulValue(100);
        maxMana.SetDefaulValue(20);
        maxStamina.SetDefaulValue(50);
        curentHeatlth = GetMaxHealth();
        curentMana = GetMaxMana();
        curentStamina = GetMaxStamina();

    }
    public float GetMaxHealth() => maxHealth.GetValue() + Vitality.GetValue() * 5;
    public float GetMaxMana() => maxMana.GetValue() + Mind.GetValue() * 5;
    public float GetMaxStamina() => maxStamina.GetValue() + Endurance.GetValue() * 5;
}
