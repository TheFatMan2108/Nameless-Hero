using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TheBullStateBattle : EnemyState
{
    private TheBullEnemy bullEnemy;
    private float timeMemory;
    public TheBullStateBattle(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        bullEnemy = enemyBase as TheBullEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        HealthBarUIForBoss.instance.SetDataBoss(bullEnemy);
        bullEnemy.SetVelocity(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Transform player = enemyBase.FindPlayer();
        if ( player!= null)
        {
            timeMemory = 3f;
            bullEnemy.transform.position = Vector2.MoveTowards(bullEnemy.transform.position, player.position, bullEnemy.GetMoveSpeed()*1.5f * Time.deltaTime);
            Flip(player.position);
            if(Vector2.Distance(player.position, bullEnemy.transform.position)<bullEnemy.distanceAttackZone)
            {
                stateMachine.ChangeState(bullEnemy.stateCanAttack);
            }
        }
        else
        {
            stateMachine.ChangeState(bullEnemy.stateIdle);
        }
    }
    public void Flip(Vector2 point)
    {
        float direction = CalculateAngle(bullEnemy.transform.position, point);
        bullEnemy.Flip(direction);
    }
}
