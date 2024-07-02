using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[Serializable]
public class InventoryItem 
{
    public ItemData itemData;
    public int stack = 0;

    public InventoryItem(ItemData itemData)
    {
        this.itemData = itemData;
        AddStack();
    }
    public void AddStack()=>stack++;
    public void RemoveStack()=>stack--;
    
}
