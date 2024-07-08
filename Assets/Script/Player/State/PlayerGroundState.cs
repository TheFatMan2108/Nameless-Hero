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
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerManager.cooldownDash < 0)
        {
            stateMachine.ChangeState(playerManager.dashState);
            return;
        }
    }
}
