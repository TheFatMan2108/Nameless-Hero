using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName) : base(stateMachine, playerManager, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isDead = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        playerManager.SetVelocity(0, 0);
    }
}
