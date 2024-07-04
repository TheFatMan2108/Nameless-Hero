using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class ControllerMainMenu : MonoBehaviour,IPointerClickHandler
{
    public GameObject mainMenu, slotNewGame,popUp;
    public static ControllerMainMenu instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        mainMenu = transform.GetChild(2).gameObject;
        slotNewGame = transform.GetChild(3).gameObject;
        popUp = transform.GetChild(4).gameObject;
    }
    #region Main Menu
    private void Start()
    {
        LoadData();
    }
    public void GameStart()
    {
        slotNewGame.SetActive(true);
    }

    public void LoadData()
    {
        foreach (SaveSlot item in slotNewGame.GetComponentsInChildren<SaveSlot>())
        {
           
            DataPersistenceManager.instance.GetAllProfilesGameData().TryGetValue(item.GetProfileId(), out GameData gameData);
            item.SetData(gameData);
        }
    }

    public void GameSetting()
    {

    }
    public void GameCredit()
    {

    }
    private void GameExit()
    {
        Application.Quit();
    }
    #endregion
    #region Slot New Game
    public void OnPopUpSaveSlot()
    {
        popUp.SetActive(true);
    }
    public void YesDelete(Action action)
    {
        popUp.GetComponent<ControllerPopUp>().YesChoice(action);
    }
    public void DeleteSaveSlot()
    {
        popUp.SetActive(true);
    }
    #endregion
    public void OnPointerClick(PointerEventData eventData)
    {
        if(popUp.activeInHierarchy)
        {
            popUp.SetActive(false);
        }
        else
        {
            slotNewGame.SetActive(false);
        }

    }

   
}
