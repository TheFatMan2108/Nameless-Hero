using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_ItemEquitment : UI_ItemInventory
{
   public EquitmentType equitmentType;

    public void UnEquitItem()
    {
        if (item == null) return;
        Inventory.Instance.UnEquitItem(item.itemData as ItemEquitment);
        WeaponManager.instance.SetWeapon(null);
        sp.sprite = null;
        Clean();
    }
}
