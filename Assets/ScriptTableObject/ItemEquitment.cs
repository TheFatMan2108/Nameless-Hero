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
}
