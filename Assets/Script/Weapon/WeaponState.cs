using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState
{
    protected WeaponStateMachine stateMachine;
    protected WeaponManager weaponManager;
    private string animBoolName;
    protected float timeAttack;
    protected bool finnishAttack;

    public WeaponState(WeaponStateMachine stateMachine, WeaponManager weaponManager, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.weaponManager = weaponManager;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        weaponManager.animator.SetBool(animBoolName, true);
        finnishAttack = false;
    }
    public virtual void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        timeAttack -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        weaponManager.animator.SetBool(animBoolName, false);
    }

    public void AnimationFinish()
    {
        finnishAttack = true;
    }
}
