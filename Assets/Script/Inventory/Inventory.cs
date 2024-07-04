using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    [SerializeField] private Transform inventorySlotParent,inventorySlotEquitment;
    [SerializeField] private List<InventoryItem> inventoryItems,inventoryEquitment;
    [SerializeField] private Dictionary<ItemData, InventoryItem> inventoryDictionary;
    [SerializeField] private Dictionary<ItemEquitment, InventoryItem> inventoryEquitmentDictionary;
    private UI_ItemInventory[] ui_ItemInventories;
    private UI_ItemEquitment[] ui_ItemEquitments;
    DataPersistenceManager dataManager;

    private void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);
        dataManager = DataPersistenceManager.instance;
    }

    private void Start()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryEquitment = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();
        inventoryEquitmentDictionary = new Dictionary<ItemEquitment, InventoryItem>();

        ui_ItemInventories = inventorySlotParent.GetComponentsInChildren<UI_ItemInventory>();
        ui_ItemEquitments = inventorySlotEquitment.GetComponentsInChildren<UI_ItemEquitment>();
        SetItemForList();
        UpdateUI();
    }

    private void SetItemForList()
    {
        foreach (InventoryItem item in dataManager.gameData.inventoryData.inventoryItems)
        {
            inventoryItems.Add(item);
            inventoryDictionary.Add(item.itemData, item); 
        }
        foreach (InventoryItem item in dataManager.gameData.inventoryData.inventoryEquitment)
        {
            AddItemInventory(item.itemData);
        }
        foreach (InventoryItem item in dataManager.gameData.inventoryData.inventoryEquitment)
        {
           EquitmentInventory(item.itemData);
            if ((item.itemData as ItemEquitment).equitmentType == EquitmentType.Weapon)
                PlayerManager.Instance.transform.GetChild(1).GetComponentInChildren<SpriteRenderer>().sprite = item.itemData.icon;
        }
    }

    public void UpdateUI()
    {
        foreach (UI_ItemInventory item in ui_ItemInventories)
        {
            item.Clean();
        }
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            ui_ItemInventories[i].UpdateItemData(inventoryItems[i]);
        }
        for(int i = 0;i < ui_ItemEquitments.Length; i++)
        {
            foreach (KeyValuePair<ItemEquitment,InventoryItem> item in inventoryEquitmentDictionary)
            {
                if (item.Key.equitmentType == ui_ItemEquitments[i].equitmentType)
                    ui_ItemEquitments[i].UpdateItemData(item.Value);
            }
        }
    }
    public void UnEquitItem(ItemEquitment newItemEqutmentDelete)
    {
        if (newItemEqutmentDelete != null && inventoryEquitmentDictionary.TryGetValue(newItemEqutmentDelete, out InventoryItem value))
        {
            inventoryEquitment.Remove(value);
            inventoryEquitmentDictionary.Remove(newItemEqutmentDelete);
            AddItemInventory(newItemEqutmentDelete);
           newItemEqutmentDelete.RemoveModifier();
        }
    }
    public void EquitmentInventory(ItemData _item)
    {
        ItemEquitment itemEquitment = _item as ItemEquitment;
        ItemEquitment oldItem = null;
        InventoryItem inventoryItem = new InventoryItem(itemEquitment);
        foreach (KeyValuePair<ItemEquitment,InventoryItem> item in inventoryEquitmentDictionary)
        {
            if(item.Key.equitmentType == itemEquitment.equitmentType) 
                oldItem = item.Key;
        }
        UnEquitItem(oldItem);
        inventoryEquitment.Add(inventoryItem);
        inventoryEquitmentDictionary.Add(itemEquitment, inventoryItem);
        RemoveItem(_item);
        itemEquitment.AddModifier();
    }
    public void AddItemInventory(ItemData item)
    {
        if (inventoryDictionary.TryGetValue(item, out InventoryItem value))
        {
            Debug.Log(value);
            value.AddStack();
        }
        else
        {
            InventoryItem inventoryItem = new InventoryItem(item);
            inventoryItems.Add(inventoryItem);
            inventoryDictionary.Add(item, inventoryItem );
            Debug.Log(inventoryDictionary.Count);
        }
        UpdateUI();
    }
    public void RemoveItem(ItemData itemData)
    {
        if (inventoryDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            if (value.stack <= 1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(itemData);
            }
            else
            {
                value.RemoveStack();
            }
        }
        UpdateUI();
    }

    public ItemEquitment GetEquitment(EquitmentType type)
    {
        ItemEquitment equitment = null;
        foreach (KeyValuePair<ItemEquitment, InventoryItem> item in inventoryEquitmentDictionary)
        {
            if (item.Key.equitmentType == type)
            {
                equitment = item.Key;
                break;
            }
        }
        return equitment;
    }
    public void SaveData()
    {
        dataManager.gameData.inventoryData.inventoryItems = inventoryItems;
        dataManager.gameData.inventoryData.inventoryEquitment = inventoryEquitment;
    }
}
