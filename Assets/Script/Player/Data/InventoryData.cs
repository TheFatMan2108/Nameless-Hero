using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class InventoryData 
{
    public List<InventoryItem> inventoryItems, inventoryEquitment;

    public InventoryData()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryEquitment = new List<InventoryItem> ();
    }
}
