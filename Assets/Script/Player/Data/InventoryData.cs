using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class InventoryData 
{
    public SerializableDictionary<string, int> inventory,equitment;
    public InventoryData()
    {
        inventory = new SerializableDictionary<string, int>();
        equitment = new SerializableDictionary<string, int>();
    }
}
