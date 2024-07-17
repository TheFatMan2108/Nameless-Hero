using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TheBullEnemy : Enemy
{
    public float distanceAttackZone;
    #region State
    public TheBullStateIdle stateIdle { get; private set; }
    public TheBullStateMove stateMove { get; private set; }
    public TheBullStateDash stateDash { get; private set; }
    public TheBullStateBattle stateBattle { get; private set; }
    public TheBullStateCanAttack stateCanAttack { get; private set; }
    public TheBullStateDead stateDead { get; private set; }

    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateIdle = new TheBullStateIdle(this, enemyStateMachine, "Idle");
        stateMove = new TheBullStateMove(this, enemyStateMachine, "Move");
        stateDash = new TheBullStateDash(this, enemyStateMachine, "Dash");
        stateBattle = new TheBullStateBattle(this, enemyStateMachine, "Move");
        stateCanAttack = new TheBullStateCanAttack(this, enemyStateMachine, "Attack");
        stateDead = new TheBullStateDead(this, enemyStateMachine, "Dead");
    }

    protected override void Reset()
    {
        base.Reset();
    }

    protected override void Start()
    {
        base.Start();
        enemyStateMachine.Initialize(stateIdle);
    }

    protected override void Update()
    {
        base.Update();
        enemyStateMachine.enemyState.Update();
    }

    public override void Dead()
    {
        base.Dead();
        enemyStateMachine.ChangeState(stateDead);
        if(!isDead)  hideBar();
        GameManager.Instance.SetCurrentForQuest(1);
       
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceAttackZone);
    }
    public void IsTriggerCalled()
    {
        enemyStateMachine.enemyState.IsTriggerCalled();
    }
}
