using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroundState : SlimeState
{
    protected SlimeEnemy enemy;
    public SlimeGroundState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, SlimeEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
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
        
    }
    public override void IsTriggerCalled()
    {
        base.IsTriggerCalled();
    }
}
