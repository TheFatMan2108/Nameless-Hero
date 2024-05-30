using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
   private SlimeEnemy slimeEnemy;

    private void Awake()
    {
        slimeEnemy = GetComponentInParent<SlimeEnemy>();
    }
    public void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(slimeEnemy.attackCheck.position, slimeEnemy.attackDistance);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                Player player = hit.GetComponent<Player>();
                player.TakeDamage(slimeEnemy.transform.position);
                player.entityStats.SetEnemy(slimeEnemy);
                slimeEnemy.entityStats.DoDamage(player);
            }
        }
    }
}