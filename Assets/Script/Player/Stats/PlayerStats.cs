using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    Player player;
    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (curentHeatlth <= 0) Dead();

    }

    protected override void Dead()
    {
        base.Dead();
        player.Dead();
    }

}
