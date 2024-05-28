using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStats : EnemyStats
{
    SlimeEnemy enemy;
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<SlimeEnemy>();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Dead()
    {
        base.Dead();
        enemy.Dead();
    }

}
