using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    #region Animation
    public Animator animator { get; private set; }
    #endregion
    #region State
    public WeaponStateMachine stateMachine { get; private set; }
    public WeaponIdleState idleState { get; private set; }
    public WeaponAttackState attackState { get; private set; }
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        #region Call State
        stateMachine = new WeaponStateMachine();
        idleState = new WeaponIdleState(stateMachine,this,"Idle");
        attackState = new WeaponAttackState(stateMachine, this, "Attack");
        #endregion
    }
    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.State.Update();
    }

    public void FinishAnimation()
    {
        stateMachine.State.AnimationFinish();
    }
}
