using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDeadState : EnemyState 
{
    SlimeEnemy enemy;
    public SlimeDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,SlimeEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        isDead = true;
        
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetVelocity(0, 0);
    }

    public override void Update()
    {
        base.Update();
    }

    
}
