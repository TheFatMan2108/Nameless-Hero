using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerGroundState
{
    public PlayerMovementState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName) : base(stateMachine, playerManager, animBoolName)
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

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!playerManager.isKnockBack) playerManager.SetVelocity(moveDirection * playerManager.GetMoveSpeed());
    }

    public override void Update()
    {
        base.Update();
        

        if (moveDirection.sqrMagnitude == 0) stateMachine.ChangeState(playerManager.idleState);
    }
}
