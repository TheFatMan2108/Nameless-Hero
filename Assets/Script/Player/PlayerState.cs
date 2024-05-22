using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player playerManager;
    protected Vector2 moveDirection;
    protected float dashArea;
    private string animBoolName;
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
    public virtual void Update()
    {
        PlayAnimation(playerManager.GetMouseDirection().normalized);
        moveDirection = playerManager.moverVector;
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

    private void PlayAnimation(Vector2 mousePosition)
    {
        playerManager.animator.SetFloat("Horizontal", mousePosition.normalized.x);
        playerManager.animator.SetFloat("Vertical", mousePosition.normalized.y);
    }
}
