using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState enemyState { get; private set; }
    public void Initialize(EnemyState enemyState)
    {
        this.enemyState = enemyState;
        enemyState.Enter();
    }

    public void ChangeState(EnemyState enemyState)
    {
        this.enemyState.Exit();
        this.enemyState = enemyState;
        this.enemyState.Enter();
    }
}
