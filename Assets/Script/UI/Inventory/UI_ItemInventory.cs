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
    protected SpriteRenderer sp;
    protected Player player;
    private void Awake()
    {
        UpdateItemData(null);
    }
    private void Start()
    {
        sp = PlayerManager.Instance.transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        player = PlayerManager.Instance.GetComponent<Player>();
    }
    private void Reset()
    {
        icon = transform.GetChild(0).gameObject;
        amount = transform.GetChild(1).gameObject;

    }
    public void UpdateItemData(InventoryItem _item)
    {
        item = _item;
        if (item != null)
        {
            icon.SetActive(true);
            amount.SetActive(true);
            icon.GetComponent<Image>().sprite = item.itemData.icon;
            if (item.stack <= 1) amount.SetActive(false);
            else
            {
                amount.SetActive(true);
                amount.GetComponentInChildren<TMP_Text>().text = item.stack.ToString();
            }
        }
        else
        {
            icon.SetActive(false);
            amount.SetActive(false);
        }
       
    }
    public void Clean()
    {
        item = null;
        icon.SetActive(false);
        amount.SetActive(false);
        player.status.SetStatus();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void EnterOK()
    {
        if(item == null)return;
        if (item.itemData.type == ItemType.Equitment)
        {
            if ((item.itemData as ItemEquitment).equitmentType == EquitmentType.Weapon)
                sp.sprite = item.itemData.icon;
            Inventory.Instance.EquitmentInventory(item.itemData);
            player.status.SetStatus();
        }
        


    }
}
