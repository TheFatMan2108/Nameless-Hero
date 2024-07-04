using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[Serializable]
public enum ItemType
{
    Masterial, Equitment
}
[Serializable]
[CreateAssetMenu(fileName = "Item Data ", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public string ID;
    public string itemName;
    public Sprite icon;
    public ItemType type;
    [Range(0.1f, 100f)]
    public float dropRate;

    private void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        ID = AssetDatabase.AssetPathToGUID(path);
#endif
    }
}
