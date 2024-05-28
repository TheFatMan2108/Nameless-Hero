using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    protected override void Start()
    {
        base.Start();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if(curentHeatlth<=0)Dead();
    }

    protected override void Dead()
    {
        base.Dead();
    }

}
