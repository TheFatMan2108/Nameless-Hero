using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackState : WeaponState
{
    protected int attackCounter;
    protected float attackTimer;
    protected float comboWindow = 2f;
    protected Vector2 directionAttack;
    public WeaponAttackState(WeaponStateMachine stateMachine, WeaponManager weaponManager, string animBoolName) : base(stateMachine, weaponManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timeAttack = 0.1f;
        if(attackCounter > 2||Time.time > attackTimer+comboWindow) attackCounter = 0;
        weaponManager.animator.SetInteger("AttackCounter",attackCounter);
        GetDirection();
        weaponManager.playerManager.SetVelocity(weaponManager.attackMovement[attackCounter]*directionAttack.x, weaponManager.attackMovement[attackCounter]*directionAttack.y);
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
        if (timeAttack < 0&&!weaponManager.playerManager.isAttackBusy) weaponManager.playerManager.SetVelocity(0, 0);
        if (finnishAttack) stateMachine.ChangeState(weaponManager.idleState); 
    }
    private void GetDirection()
    {
        float x = weaponManager.playerManager.GetMouseDirection().x;
        float y = weaponManager.playerManager.GetMouseDirection().y;
        #region changeDirection
        x = Eounding(x);
        y = Eounding(y);
        #endregion
        directionAttack = new Vector2(x, y);
    }
    private float Eounding(float num)
    {
        if (num < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
