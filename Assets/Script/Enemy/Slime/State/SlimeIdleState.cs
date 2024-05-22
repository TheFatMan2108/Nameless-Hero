using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState :SlimeGroundState
{
    public SlimeIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, SlimeEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timmerState = 3;
       
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timmerState < 0) stateMachine.ChangeState(enemy.moveState);
    }
    public override void IsTriggerCalled()
    {
        base.IsTriggerCalled();
    }
}
