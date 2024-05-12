using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine 
{
    public WeaponState State { get; private set; }

    public void Initialize(WeaponState state)
    {
        this.State = state;
        this.State.Enter();
    }

    public void ChangeState(WeaponState state)
    {
        this.State.Exit();
        this.State = state;
        this.State.Enter();

    }
}
