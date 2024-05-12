using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackState : WeaponState
{
    protected int attackCounter;
    protected float attackTimer;
    protected float comboWindow = 2f;
    public WeaponAttackState(WeaponStateMachine stateMachine, WeaponManager weaponManager, string animBoolName) : base(stateMachine, weaponManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timeAttack = 0.1f;
        if(attackCounter > 2||Time.time > attackTimer+comboWindow) attackCounter = 0;
        weaponManager.animator.SetInteger("AttackCounter",attackCounter);
    }

    public override void Exit()
    {
        base.Exit();
        attackCounter++;
        attackTimer = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (finnishAttack) stateMachine.ChangeState(weaponManager.idleState); 
    }
}
