using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    protected float dashForce = 10f;
    public PlayerDashState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName) : base(stateMachine, playerManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerManager.SetAttackBusy(true);
        dashArea = 0.5f;
        playerManager.SetCooldown(1.5f);
        moveDirection = playerManager.GetMouseDirection().normalized;
        playerManager.SetVelocity(moveDirection * dashForce);
        playerManager.OnGhost();
        playerManager.IframePlayer(true);
    }

    public override void Exit()
    {
        base.Exit();
        playerManager.SetAttackBusy(false);
        playerManager.IframePlayer(false);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
       
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
    #region Not User
    private Vector2 GetDirection()
    {
        float x = playerManager.GetMouseDirection().x;
        float y = playerManager.GetMouseDirection().y;
        #region changeDirection
        x = Eounding(x);
        y = Eounding(y);
        #endregion
        Debug.Log("" + x + "," + y);
        return new Vector2(x, y);
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
    #endregion
}
