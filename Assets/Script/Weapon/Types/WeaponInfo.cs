using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponInfo
{
    public string nameWeapon;
    public int level;
    public WeaponRarity weaponRarity;
    public float strength;
    public float damageDefault;
    public float speed;
    public WeaponElementalFactor WeaponElementalFactor;
    public WeaponStatsRequire WeaponStatsRequire;
    private float scaleToRarity;
    public float GetDamage()
    {
        switch (weaponRarity)
        {
            case WeaponRarity.Common:
                scaleToRarity = 1.0f;
                break;
            case WeaponRarity.Uncommon: 
                scaleToRarity = 1.5f;
                break;
            case WeaponRarity.Rare:
                scaleToRarity = 1.7f;
                break;
            case WeaponRarity.Epic:
                scaleToRarity = 2f;
                break;
            case WeaponRarity.Legendary:
                scaleToRarity = 2.5f;
                break;
        }
        return (strength * damageDefault*scaleToRarity)
            +(speed*(damageDefault/speed)*scaleToRarity 
            + (level*GetDamageElementalFactor())) * scaleToRarity;
    }
    private float GetDamageElementalFactor()
    {
        return (WeaponElementalFactor.fire + WeaponElementalFactor.ice + WeaponElementalFactor.lightning)/3;
    }
}
public enum WeaponRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
