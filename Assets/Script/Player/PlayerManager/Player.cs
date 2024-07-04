using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    #region Level
    public LevelSystem levelSystem;
    #endregion
    #region Input
    public Vector2 moverVector { get; private set; }
    public Vector2 mousePosition { get; private set; }
    #endregion
    #region Animation
    public Animator animator { get; private set; }
    public GhostEffectSystem effectSystem { get; private set; }
    #endregion
    #region Collision
    public Rigidbody2D rb { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMovementState movementState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    #endregion
    #region Stats
    public float cooldownDash;
    public bool isAttackBusy { get; private set; }
    #endregion
    #region Weapons
    private WeaponParent weaponParent;
    #endregion
    
    
    protected override void Awake()
    {
        base.Awake();
        levelSystem = DataPersistenceManager.instance.gameData.levelSystem;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        effectSystem = transform.GetChild(2).GetComponentInChildren<GhostEffectSystem>();
        // tets sau nay lam he thong tao nhan vat
        #region Call States
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(playerStateMachine, this, "Idle");
        movementState = new PlayerMovementState(playerStateMachine, this, "Move");
        dashState = new PlayerDashState(playerStateMachine, this, "Dash");
        deadState = new PlayerDeadState(playerStateMachine, this, "Dead");
        #endregion
    }

    protected override void Start()
    {
        base.Start();
        playerStateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        playerStateMachine.State.Update();
        weaponParent.pointerposition = mousePosition;
        cooldownDash -= Time.deltaTime;
    }

    public void OnMover(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            moverVector = callback.ReadValue<Vector2>();
        }
        else
        {
            moverVector = Vector2.zero;
        }
    }
    public void GetMousePosition(InputAction.CallbackContext callback)
    {
        Vector3 mousePos = callback.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
       
    }
    public Vector2 GetMouseDirection()
    {
        return (mousePosition - new Vector2(transform.position.x, transform.position.y));
    }
 

    public void OnGhost()
    {
        effectSystem.SetOnGhostAnimation(true,GetComponent<SpriteRenderer>());
    }
    public void OffGhost()
    {
        effectSystem.SetOnGhostAnimation(false);
    }

    public void SetCooldown(float cooldown)
    {
        this.cooldownDash = cooldown;
    }

    public override void Dead()
    {
        base.Dead();
        playerStateMachine.ChangeState(deadState);
    }

}
