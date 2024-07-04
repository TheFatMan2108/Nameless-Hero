using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteChar, spriteWeapon;
  public Vector2 pointerposition {  get;  set; }

    private void Update()
    {
        if (PlayerManager.Instance.player.isDead) return; 
        Vector2 direction = (pointerposition - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            spriteWeapon.sortingOrder = spriteChar.sortingOrder - 1;
        }
        else
        {
            spriteWeapon.sortingOrder = spriteChar.sortingOrder + 1;
        }
    }
}
