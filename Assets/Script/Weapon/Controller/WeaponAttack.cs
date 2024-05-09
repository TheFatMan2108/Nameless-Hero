using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAttack : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
      animator = GetComponent<Animator>();  
    }

    public void Attacked(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            animator.Play("Attacked");
        }
        
    }

}
