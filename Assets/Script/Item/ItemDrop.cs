using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int amountDrop,fireTimeDrop,exp;
    [SerializeField] private ItemData[] canDropList;
    [SerializeField] private GameObject objectDrop,fireTime;
    private List<ItemData> dropList = new List<ItemData>();


    public void GenerateDrop()
    {
        for (int i = 0; i < canDropList.Length; i++)
        {
            if (Random.Range(0f, 100f) <= canDropList[i].dropRate)
                dropList.Add(canDropList[i]);
        }

        for (int i = 0; i < amountDrop; i++)
        {
            if (dropList.Count > 0)
            {
                ItemData item = dropList[Random.Range(0, dropList.Count - 1)];
                dropList.Remove(item);
                DropItem(item);
            }
        }
        // viet drop coin o day
        GameObject fireCoin = Instantiate(fireTime,transform.position,Quaternion.identity);
        fireCoin.GetComponent<ParticleCollector>().totalFireTime = fireTimeDrop;
        Destroy(fireCoin,100);
        PlayerManager.Instance.player.AddExp(exp);
    }
    private async void Reset()
    {
        objectDrop = await AddressLoader.LoaderAddress<GameObject>("Assets/Prefab/Item/ItemDrop.prefab");
    }
    public void DropItem(ItemData item)
    {
        GameObject newGameObject = Instantiate(objectDrop, transform.position, Quaternion.identity);
        Vector2 newVelocity = new Vector2(Random.Range(-10f, 10f), Random.Range(10f, 15f));
        newGameObject.GetComponent<ItemObject>().SetupItem(item, newVelocity);
    }
}
