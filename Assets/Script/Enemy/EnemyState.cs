using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemyBase { get; private set; }
    protected EnemyStateMachine stateMachine { get; set; }
    private string animBoolName;
    protected float timmerState;
    protected bool triggerCalled;
    protected bool isDead;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        enemyBase.animator.SetBool(animBoolName, true);
    }
    public virtual void Update()
    {
        if(isDead) return;
        timmerState -= Time.deltaTime;
    }
    public virtual void Exit()
    {
        enemyBase.animator.SetBool(animBoolName, false);
    }
    public virtual void IsTriggerCalled()
    {
        triggerCalled = true;
    }
    public float CalculateAngle(Vector2 from, Vector2 to)
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
}
