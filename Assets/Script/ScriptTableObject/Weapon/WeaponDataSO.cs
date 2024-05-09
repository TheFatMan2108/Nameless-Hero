using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newWeapon",menuName ="Data/Weapon Data",order =0)]
public class WeaponDataSO : ScriptableObject
{

    public WeaponInfo weaponInfo;
    public WeaponType weaponType;
    public Sprite sprite;
    public enum WeaponType
    {
        Sword,Knife,Staff
    }
}
