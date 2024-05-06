using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moverVector;
    private Vector2 mousePosition;
    private WeaponParent weaponParent;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        weaponParent = GetComponentInChildren<WeaponParent>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moverVector * speed * Time.fixedDeltaTime);
        PlayAnimation();
        weaponParent.pointerposition = mousePosition;
    }

    private void PlayAnimation()
    {
        animator.SetFloat("Horizontal", mousePosition.normalized.x);
        animator.SetFloat("Vertical", mousePosition.normalized.y);
        animator.SetFloat("Speed",moverVector.sqrMagnitude);
    }

    public void OnMover(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            moverVector = callback.ReadValue<Vector2>() ;
            
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

}
