using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
    private GetData getData;
    public SpriteRenderer spriteWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            getData = collision.GetComponent<GetData>();
            spriteWeapon.sprite = getData.weaponDataSO.sprite;
            Destroy(collision.gameObject);
        }
    }
}
