using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    protected Vector2 dashDirection;
    protected float dashForce = 10f;
    public PlayerDashState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName) : base(stateMachine, playerManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerManager.SetAttackBusy(true);
        dashArea = 0.2f;
        playerManager.SetCooldown(1.5f);
        GetDirection();
        playerManager.SetVelocity(dashDirection * dashForce);
        playerManager.OnGhost();
    }

    private void GetDirection()
    {
        float x = playerManager.GetMouseDirection().x;
        float y = playerManager.GetMouseDirection().y;
        #region changeDirection
        x = Eounding(x);
        y = Eounding(y);
        #endregion
        dashDirection = new Vector2(x, y);
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

    public override void Exit()
    {
        base.Exit();
        playerManager.SetAttackBusy(false);

    }

    public override void Update()
    {
        base.Update();
        if (dashArea < 0)
        {
            playerManager.OffGhost();
            stateMachine.ChangeState(playerManager.idleState);
            playerManager.SetVelocity(Vector2.zero);
        }
    }
}
