using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    private PlayerStats playerStats;
    void Start()
    {
        playerStats = PlayerManager.Instance.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            playerStats.DoMagicDamage(enemy);
        }
    }
}
