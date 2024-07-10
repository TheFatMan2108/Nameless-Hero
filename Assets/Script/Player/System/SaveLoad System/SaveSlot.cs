using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour,IPointerClickHandler
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI fireTime,level,timePlay,hp;

    [Header("Clear Data Button")]
    [SerializeField] private Button clearButton;
    private ControllerMainMenu menu;
    public bool hasData { get; private set; } = false;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        // there's no data for this profileId
        if (data == null)
        {
            hasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            clearButton.gameObject.SetActive(false);
        }
        // there is data for this profileId
        else
        {
            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            clearButton.gameObject.SetActive(true);

            level.text = "Level: "+data.levelSystem.level.ToString();
            hp.text = "HP: "+data.statsData.curentHeatlth+"/"+data.statsData.GetMaxHealth();
            DateTime dateFromBinary = DateTime.FromBinary(data.lastUpdated);
            timePlay.text = dateFromBinary.ToString("HH:mm:ss dd/MM/yyyy");
            fireTime.text = data.fireTime.ToString("n0");
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
        clearButton.interactable = interactable;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasDataContent.activeInHierarchy)
        {
            // load
            DataPersistenceManager.instance.ChangeSelectedProfileId(GetProfileId());
            DataPersistenceManager.instance.LoadGame();
            // sau nay load ten the gioi player dang o
            SceneManager.LoadScene("OverWord");

        }
        else
        {
            // new game
            DataPersistenceManager.instance.ChangeSelectedProfileId(GetProfileId());
            DataPersistenceManager.instance.NewGame();
            SceneManager.LoadScene("OverWord");
        }
    }
    public void OnDelete()
    {
        menu = ControllerMainMenu.instance;
        menu.OnPopUpSaveSlot();
        menu.YesDelete(() => Delete());
        clearButton.onClick.RemoveAllListeners();
    }
    private void Delete()
    {

        DataPersistenceManager.instance.ChangeSelectedProfileId(GetProfileId());
        DataPersistenceManager.instance.DeleteProfileData(GetProfileId());
        menu.LoadData();
        menu.popUp.SetActive(false);

    }
}
