using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullStateIdle : EnemyState
{
    TheBullEnemy bullEnemy;
    public TheBullStateIdle(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        bullEnemy = (enemyBase as TheBullEnemy);
    }

    public override void Enter()
    {
        base.Enter();
        timmerState = 1;
        bullEnemy.SetVelocity(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timmerState < 0) stateMachine.ChangeState(bullEnemy.stateMove);
    }
}
