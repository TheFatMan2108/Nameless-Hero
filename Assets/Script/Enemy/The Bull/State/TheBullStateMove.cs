using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTargetGroup;

public class TheBullStateMove : EnemyState
{
    private Vector2 point;
    private TheBullEnemy bullEnemy;
    public TheBullStateMove(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        bullEnemy = enemyBase as TheBullEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        bullEnemy.SetVelocity(Vector3.zero);
        point = new Vector2(Random.Range(bullEnemy.transform.position.x - enemyBase.GetDistanceBetween(), bullEnemy.transform.position.x + enemyBase.GetDistanceBetween()),
        Random.Range(bullEnemy.transform.position.y - enemyBase.GetDistanceBetween(), bullEnemy.transform.position.y + enemyBase.GetDistanceBetween()));
        Flip();
    }
    public void Flip()
    {
        float direction = CalculateAngle(bullEnemy.transform.position,point);
        bullEnemy.Flip(direction);
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemyBase.FindPlayer() == null) stateMachine.ChangeState(bullEnemy.stateIdle);
        else
        {
            float direction = CalculateAngle(bullEnemy.transform.position, enemyBase.FindPlayer().position);
            bullEnemy.Flip(direction);
            stateMachine.ChangeState(bullEnemy.stateDash);
        }
    }

    private void Move()
    {
        // dung sau hoac khong
        bullEnemy.transform.position = Vector2.MoveTowards(bullEnemy.transform.position, point, bullEnemy.GetMoveSpeed() * Time.deltaTime);
        if (point == (Vector2)bullEnemy.transform.position) stateMachine.ChangeState(bullEnemy.stateIdle);
    }
}
