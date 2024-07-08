using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPopUp : MonoBehaviour
{
    [SerializeField] private GameObject yesButton, noButton;
    public void YesChoice(Action action)
    {
        yesButton.GetComponent<Button>().onClick.RemoveAllListeners();
        yesButton.GetComponent<Button>().onClick.AddListener(()=>action());
    }
    private void OnEnable()
    {
        noButton.GetComponent<Button>().onClick.RemoveAllListeners();
        noButton.GetComponent<Button>().onClick.AddListener(()=>NoChoice());
    }
    public void NoChoice()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        yesButton.GetComponent<Button>().onClick.RemoveAllListeners();
        noButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

}
