using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ItemData itemData;
    private void OnValidate()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (itemData == null) return;
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name = itemData.itemName;
    }
    public void SetupItem(ItemData itemData, Vector2 velocity)
    {
        this.rb.velocity = velocity;
        this.itemData = itemData;
        LoadData();
        StartCoroutine(StopDrop());
    }
    IEnumerator StopDrop()
    {
        rb.velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, -15f));
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector2.zero;
    }
    public void PickUpItem()
    {
        Destroy(gameObject);
        Inventory.Instance.AddItemInventory(itemData);
    }
}
