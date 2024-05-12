using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    #region Data Mananger
    public Character character;
    #endregion
    #region Input
    public Vector2 moverVector { get; private set; }
    public Vector2 mousePosition { get; private set; }
    #endregion
    #region Animation
    public Animator animator { get; private set; }
    #endregion
    #region Collision
    public Rigidbody2D rb { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMovementState movementState { get; private set; }
    #endregion
    #region Stats
    public float speed;
    #endregion
    #region Weapons
    private WeaponParent weaponParent;
    #endregion
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        #region Call States
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(playerStateMachine, this, "Idle");
        movementState = new PlayerMovementState(playerStateMachine, this, "Move");
        #endregion
    }
    void Start()
    {
        playerStateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        playerStateMachine.State.Update();
        weaponParent.pointerposition = mousePosition;
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
}
