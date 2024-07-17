using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullAnimationTrigger : MonoBehaviour
{
   private TheBullEnemy bullEnemy;
    private void Awake()
    {
        bullEnemy = GetComponentInParent<TheBullEnemy>();
    }
    public void TriggerAnimation()
    {
        bullEnemy.IsTriggerCalled();
    }
    public void ShakeCamera()=> bullEnemy.OnShakeCamera();
    public void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(bullEnemy.attackCheck.position, bullEnemy.attackDistance);
        foreach (var hit in colliders)
        {
            if (hit.TryGetComponent(out Player player))
            {
                if(player.isIframe)return;
                player.TakeDamage(bullEnemy.transform.position);
                player.entityStats.SetEnemy(bullEnemy);
                bullEnemy.entityStats.DoDamage(player);
            }
        }
    }

}
