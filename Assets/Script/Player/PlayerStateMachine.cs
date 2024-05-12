using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState State { get; private set; }

    public void Initialize(PlayerState state)
    {
        this.State = state;
        this.State.Enter();
    }

    public void ChangeState(PlayerState state)
    {
        this.State.Exit();
        this.State = state;
        this.State.Enter();

    }
}
