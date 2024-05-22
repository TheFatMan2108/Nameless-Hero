using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    #region Info

    #endregion
    #region State
    public SlimeIdleState idleState { get; private set; }
    public SlimeMoveState moveState { get; private set; }
    public SlimeAttackState attackState { get; private set; }
    #endregion
    #region Transform
    public Transform originPosition;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SlimeIdleState(this, enemyStateMachine, "Idle", this);
        moveState = new SlimeMoveState(this, enemyStateMachine, "Move", this);
        attackState = new SlimeAttackState(this, enemyStateMachine, "Attack", this);
        
    }
    protected override void Start()
    {
        base.Start();
        enemyStateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        enemyStateMachine.enemyState.Update();
        
    }
    protected override void Reset()
    {
        base.Reset();
    }

    public override void SetAttackBusy(bool busy)
    {
        base.SetAttackBusy(busy);
    }

    public override void SetVelocity(float xInput, float yInput)
    {
        base.SetVelocity(xInput, yInput);
    }

    public override void SetVelocity(Vector2 input)
    {
        base.SetVelocity(input);
    }

    public override Transform FindPlayer()
    {
        return base.FindPlayer();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
       
    }

    public override void Flip(float dir)
    {
        base.Flip(dir);
    }
}
