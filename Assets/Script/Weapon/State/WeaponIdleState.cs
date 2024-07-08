using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : WeaponState
{
    private bool isAttack;
    private float timeAttack;
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
        if(PlayerManager.Instance.player.isDead)return;
        if(!isAttack) 
            weaponManager.playerManager.entityStats.ReloadStamina(1);
        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerManager.Instance.player.entityStats.curentStamina > 0)
        {
            stateMachine.ChangeState(weaponManager.attackState);
            timeAttack = 5f;
        }
        if(timeAttack<0f)
        {
            isAttack = false;
        }
        else
        {
            isAttack=true;
        }
        timeAttack-= Time.deltaTime;
    }
}
