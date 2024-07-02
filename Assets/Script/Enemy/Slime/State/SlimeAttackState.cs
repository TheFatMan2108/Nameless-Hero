using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTargetGroup;

public class SlimeAttackState : SlimeGroundState
{
    private Vector2 playerPosition;
    private float dirFace;
    private SlimeEnemy enemy;
    public SlimeAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, SlimeEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        playerPosition = enemy.FindPlayer().position;
        Flip();
    }

    public override void Exit()
    {
        base.Exit();
    }
    private void Flip()
    {
        dirFace = CalculateAngle(enemy.transform.position, playerPosition);
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
    private void Move()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, playerPosition, enemy.GetMoveSpeed() * Time.deltaTime);
        Debug.Log("toc do cua attack + " + enemy.GetMoveSpeed());
        if (enemy.isKnockBack) enemy.Stun(2);
        if (playerPosition == (Vector2)enemy.transform.position) stateMachine.ChangeState(enemy.idleState);
    }
    public override void Update()
    {
        base.Update();
        Move();
    }
    public override void IsTriggerCalled()
    {
        base.IsTriggerCalled();
        
    }
}


