using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullStateCanAttack : EnemyState
{
    TheBullEnemy bullEnemy;
    int countCombo = 0;
    int useCombo = 0;
    public TheBullStateCanAttack(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        bullEnemy = enemyBase as TheBullEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        countCombo++;
        useCombo = Random.Range(0, 3);
        enemyBase.animator.SetInteger("AttackCounter", useCombo);
        bullEnemy.SetVelocity(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
        if (countCombo > 5) countCombo = 0;
    }

    public override void Update()
    {
        base.Update();
        if(countCombo>5) stateMachine.ChangeState(bullEnemy.stateDash);
        if (triggerCalled) stateMachine.ChangeState(bullEnemy.stateBattle);
    }
}
