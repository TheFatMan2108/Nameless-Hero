using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    [SerializeField] private int level = 1;
    [Range(0f, 1f)]
    [SerializeField] private float scale = 0.4f;
    protected ItemDrop dropSystem;
    protected Enemy enemy;
    protected override void Start()
    {
        LoadPower();
        base.Start();
        dropSystem = GetComponent<ItemDrop>();
        enemy = GetComponent<Enemy>();
    }

    private void LoadPower()
    {
        AddModify(Vitality);
        AddModify(Mind);
        AddModify(Endurance);
        AddModify(Strength);
        AddModify(Dexterity);
        AddModify(damage);
        AddModify(critChance);
        AddModify(critPower);
        AddModify(maxHealth);
        AddModify(armor);
        AddModify(magicResistance);
        AddModify(fireDamage);
        AddModify(iceDamage);
        AddModify(lightDamage);
        AddModify(bloodDamage);
        AddModify(toxicDamage);
    }

    private void AddModify(Stats stats)
    {
        for (int i = 1; i < level; i++)
        {
            float modifier = stats.GetValue() * scale;
            stats.AddModifier(Mathf.RoundToInt(modifier));
        }
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if(isMe.isDead)return;
        enemy.SetFloatingText(damage.ToString());
        (isMe as Enemy).UpdateHealth();
        if (curentHeatlth<=0)Dead();
    }

    protected override void Dead()
    {
        base.Dead();
        dropSystem.GenerateDrop();
        enemy.Dead();
    }

    protected override void ExecuteToxicDamage()
    {
        base.ExecuteToxicDamage();
    }

    protected override void ExecuteBloodDamage()
    {
        base.ExecuteBloodDamage();
    }

    protected override void ExecuteLightDamage()
    {
        base.ExecuteLightDamage();
    }

    protected override void ExecuteIceDamage()
    {
        base.ExecuteIceDamage();
    }

    protected override void ExecuteFireDamage()
    {
        base.ExecuteFireDamage();
    }
}
