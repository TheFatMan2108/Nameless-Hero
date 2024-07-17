using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullStateDash : EnemyState
{
    TheBullEnemy bullEnemy;

    public TheBullStateDash(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        bullEnemy = enemyBase as TheBullEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        timmerState = 1f;
        bullEnemy.SetVelocity(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timmerState<0) stateMachine.ChangeState(bullEnemy.stateBattle);
    }
}
