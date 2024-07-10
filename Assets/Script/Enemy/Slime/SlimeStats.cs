using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStats : EnemyStats
{
    
    protected override void Start()
    {
        base.Start();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Dead()
    {
        base.Dead();
    }

}
