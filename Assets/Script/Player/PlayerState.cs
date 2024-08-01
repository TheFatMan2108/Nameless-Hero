using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player playerManager;
    protected Vector2 moveDirection;
    protected float dashArea;
    private string animBoolName;
    protected bool isDead;
    public PlayerState(PlayerStateMachine stateMachine, Player playerManager, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.playerManager = playerManager;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        #region On
        playerManager.animator.SetBool(animBoolName,true);
        #endregion
    }
    public virtual void FixedUpdate() 
    {
    
    }
    public virtual void Update()
    {
        if(isDead) return;
        CountDownFun();
    }

    private void CountDownFun()
    {
        dashArea -= Time.deltaTime;
    }


    public virtual void Exit()
    {
        #region Off
        playerManager.animator.SetBool(animBoolName, false);
        #endregion
    }

    protected virtual void PlayAnimation(Vector2 mousePosition)
    {
        playerManager.animator.SetFloat("Horizontal", mousePosition.normalized.x);
        playerManager.animator.SetFloat("Vertical", mousePosition.normalized.y);
    }
}
