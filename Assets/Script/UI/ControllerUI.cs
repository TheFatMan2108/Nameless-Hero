using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerUI : MonoBehaviour
{
    private GameObject menu;
    private void Awake()
    {
        menu = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        ControllerMenu();
    }
    public void Menu(InputAction.CallbackContext callback)
    {
        ControllerMenu();
    }

    public void ControllerMenu()
    {
        if (menu.activeInHierarchy)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }
}
