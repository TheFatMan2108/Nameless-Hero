using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemInventory : MonoBehaviour, IPointerDownHandler
{
    public InventoryItem item;
    public GameObject icon, amount;

    private void Awake()
    {
        UpdateItemData(null);
    }
    public void UpdateItemData(InventoryItem _item)
    {
        item = _item;
        if (item != null)
        {
            icon.SetActive(true);
            amount.SetActive(true);
            icon.GetComponent<Image>().sprite = item.itemData.icon;
            if (item.stack <= 1)amount.SetActive(false);
            else
            {
            amount.SetActive(true);
            amount.GetComponentInChildren<TMP_Text>().text = item.stack.ToString();
            }
        }
        else
        {
            Clean();
        }
    }
    public void Clean()
    {
        item = null;
        icon.SetActive(false);
        amount.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(item==null)return;
        if(item.itemData.type == ItemType.Equitment)
        {
            Inventory.Instance.EquitmentInventory(item.itemData);
        }
    }
    public void EnterOK()
    {
        if (item == null) return;
        if (item.itemData.type == ItemType.Equitment)
        {
            Inventory.Instance.EquitmentInventory(item.itemData);
        }
    }
}
