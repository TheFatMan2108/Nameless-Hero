using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullStats : EnemyStats
{
    public override void DoDamage(Entity entity)
    {
        base.DoDamage(entity);
    }

    public override void DoMagicDamage(Entity entityStats)
    {
        base.DoMagicDamage(entityStats);
    }

    protected override void Dead()
    {
        base.Dead();
    }

    protected override void ExecuteBloodDamage()
    {
        base.ExecuteBloodDamage();
    }

    protected override void ExecuteFireDamage()
    {
        base.ExecuteFireDamage();
    }

    protected override void ExecuteIceDamage()
    {
        base.ExecuteIceDamage();
    }

    protected override void ExecuteLightDamage()
    {
        base.ExecuteLightDamage();
    }

    protected override void ExecuteToxicDamage()
    {
        base.ExecuteToxicDamage();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
