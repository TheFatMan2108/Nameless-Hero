using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStun : EnemyState
{
    SlimeEnemy slimeEnemy;
    
    public SlimeStun(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, SlimeEnemy slimeEnemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.slimeEnemy = slimeEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        timmerState = slimeEnemy.timeStun;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // lam no dung dung kieu nhu la bi dien giat
        if(timmerState<0)stateMachine.ChangeState(slimeEnemy.moveState);
    }

    public override void IsTriggerCalled()
    {
        base.IsTriggerCalled();
    }
}
