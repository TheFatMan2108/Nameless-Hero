using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName) : base(stateMachine, playerManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        playerManager.SetVelocity(Vector2.zero);
    }

    public override void Update()
    {
        base.Update();
        PlayAnimation(playerManager.GetMouseDirection().normalized);
        moveDirection = playerManager.moverVector.normalized;
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerManager.cooldownDash < 0)
        {
            stateMachine.ChangeState(playerManager.dashState);
        }
    }
}
