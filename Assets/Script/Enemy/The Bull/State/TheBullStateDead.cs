using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullStateDead : EnemyState
{
    public TheBullStateDead(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
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
        enemyBase.SetVelocity(Vector2.zero);
    }
}
