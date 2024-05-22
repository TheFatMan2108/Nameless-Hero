using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : SlimeGroundState
{
    private float x, y;
    private Vector2 positionMove;
    private float dirFace;
    private float zoneMove = 3;
    public SlimeMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, SlimeEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        x = Random.Range(enemy.originPosition.position.x - zoneMove, enemy.originPosition.position.x + zoneMove);
        y = Random.Range(enemy.originPosition.position.y - zoneMove, enemy.originPosition.position.y + zoneMove);
        positionMove = new Vector2(x, y);
        Flip();
    }

    private void Flip()
    {
        dirFace = CalculateAngle(enemy.transform.position, positionMove);
        enemy.Flip(dirFace);
    }
    float CalculateAngle(Vector2 from, Vector2 to)
    {
        float deltaX = to.x - from.x;
        if (deltaX < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (enemy.FindPlayer() == null) Move();
        else stateMachine.ChangeState(enemy.attackState);
    }

    private void Move()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, positionMove, 5 * Time.deltaTime);
        if (positionMove == (Vector2)enemy.transform.position) stateMachine.ChangeState(enemy.idleState);
    }

    public override void IsTriggerCalled()
    {
        base.IsTriggerCalled();
    }
}
