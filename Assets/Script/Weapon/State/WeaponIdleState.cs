using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : WeaponState
{
    public WeaponIdleState(WeaponStateMachine stateMachine, WeaponManager weaponManager, string animBoolName) : base(stateMachine, weaponManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0)) stateMachine.ChangeState(weaponManager.attackState);
    }
}
