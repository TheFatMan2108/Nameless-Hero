using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquitmentType
{
    Weapon,
    Armor,
    Flask
}
[CreateAssetMenu(fileName = "Equitment item ", menuName = "Data/Equitment")]
public class ItemEquitment : ItemData
{
    public EquitmentType equitmentType;
    public ItemEffect[] listItemEffect;
    
    [Header("Stats")]
    public float Vitality;
    public float Mind;
    public float Endurance;
    public float Strength;
    public float Dexterity;
    public float Intelligence;
    [Header("Offensive")]
    public float damage;
    public float critChance;
    public float critPower;
    [Header("Defaul Stats")]
    public float maxHealth;
    public float armor;
    public float magicResistance;
    [Header("Macgic Stats")]
    public float fireDamage;
    public float iceDamage;
    public float lightDamage;
    public float bloodDamage;
    public float toxicDamage;

    public void ExecuteItemEffect(Transform positonEnemy)
    {
        foreach (var effect in listItemEffect)
        {
            effect.ExecuteEffect(positonEnemy);
        }
    }
    public void AddModifier()
    {
        PlayerStats myStats = PlayerManager.Instance.GetComponent<PlayerStats>();
        myStats.Vitality.AddModifier(Vitality);
        myStats.Mind.AddModifier(Mind);
        myStats.Endurance.AddModifier(Endurance);
        myStats.Strength.AddModifier(Strength);
        myStats.Dexterity.AddModifier(Dexterity);
        myStats.Intelligence.AddModifier(Intelligence);
        myStats.damage.AddModifier(damage);
        myStats.critChance.AddModifier(critChance);
        myStats.critPower.AddModifier(critPower);
        myStats.maxHealth.AddModifier(maxHealth);
        myStats.armor.AddModifier(armor);
        myStats.magicResistance.AddModifier(magicResistance);
        myStats.fireDamage.AddModifier(fireDamage);
        myStats.iceDamage.AddModifier(iceDamage);
        myStats.lightDamage.AddModifier(lightDamage);
        myStats.bloodDamage.AddModifier(bloodDamage);
        myStats.toxicDamage.AddModifier(toxicDamage);
        myStats.ReloadStats();
    }

    public void RemoveModifier()
    {
        PlayerStats myStats = PlayerManager.Instance.GetComponent<PlayerStats>();
        myStats.Vitality.RemoveModifier(Vitality);
        myStats.Mind.RemoveModifier(Mind);
        myStats.Endurance.RemoveModifier(Endurance);
        myStats.Strength.RemoveModifier(Strength);
        myStats.Dexterity.RemoveModifier(Dexterity);
        myStats.Intelligence.RemoveModifier(Intelligence);
        myStats.damage.RemoveModifier(damage);
        myStats.critChance.RemoveModifier(critChance);
        myStats.critPower.RemoveModifier(critPower);
        myStats.maxHealth.RemoveModifier(maxHealth);
        myStats.armor.RemoveModifier(armor);
        myStats.magicResistance.RemoveModifier(magicResistance);
        myStats.fireDamage.RemoveModifier(fireDamage);
        myStats.iceDamage.RemoveModifier(iceDamage);
        myStats.lightDamage.RemoveModifier(lightDamage);
        myStats.bloodDamage.RemoveModifier(bloodDamage);
        myStats.toxicDamage.RemoveModifier(toxicDamage);
        myStats.ReloadStats();
    }
}
