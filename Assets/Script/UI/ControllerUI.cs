using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    private GameObject inventory,menu;
    private Player player;
    private List<TextMeshProUGUI> statsText = new List<TextMeshProUGUI>(); 
    private List<Button> buttonStart = new List<Button>(); 
    private void Awake()
    {
        inventory = transform.GetChild(0).gameObject;
        menu = transform.GetChild(2).gameObject;
    }
    private void Start()
    {
        player = PlayerManager.Instance.player;
        StatsDataFun();
        AddMenu();
        ControllerInventory();
        ControllerMenu();
        player.levelUp += LoadStats;
    }

    private void AddMenu()
    {
        menu.transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(ControllerMenu);
        menu.transform.GetChild(0).GetChild(1).GetComponent<Button>();// them ham setting
        menu.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(BackToMenu);
    }

    private void StatsDataFun()
    {
       inventory.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = player.levelSystem.pointStats.ToString();
       for(int i = 0; i < inventory.transform.GetChild(4).childCount; i++)
        {
           GameObject stats = inventory.transform.GetChild(4).GetChild(i).gameObject;
           statsText.Add(stats.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            buttonStart.Add(stats.transform.GetChild(2).GetComponent<Button>());
        }
        buttonStart[0].onClick.AddListener(()=> AddStats(ref player.entityStats.Vitality));
        buttonStart[1].onClick.AddListener(() => AddStats(ref player.entityStats.Mind));
        buttonStart[2].onClick.AddListener(() => AddStats(ref player.entityStats.Endurance));
        buttonStart[3].onClick.AddListener(() => AddStats(ref player.entityStats.Strength));
        buttonStart[4].onClick.AddListener(() => AddStats(ref player.entityStats.Dexterity));
        buttonStart[5].onClick.AddListener(() => AddStats(ref player.entityStats.Intelligence));
        LoadStats();
    }

    public void LoadStats()
    {
        inventory.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = player.levelSystem.pointStats.ToString();
        statsText[0].text = player.entityStats.Vitality.GetBaseValue().ToString();
        statsText[1].text = player.entityStats.Mind.GetBaseValue().ToString();
        statsText[2].text = player.entityStats.Endurance.GetBaseValue().ToString();
        statsText[3].text = player.entityStats.Strength.GetBaseValue().ToString();
        statsText[4].text = player.entityStats.Dexterity.GetBaseValue().ToString();
        statsText[5].text = player.entityStats.Intelligence.GetBaseValue().ToString();

        if (player.levelSystem.pointStats < 1)
        {
            foreach (Button button in buttonStart)
            {
                button.interactable = false;
            }
        }
        else
        {
            foreach (Button button in buttonStart)
            {
                button.interactable = true;
            }
        }
    }
    private void AddStats(ref Stats stats)
    {
        player.levelSystem.pointStats--;
        stats.AddValue(1);
        LoadStats();
    }
    public void Inventory(InputAction.CallbackContext callback)
    {
        ControllerInventory();
    }

    public void Menu(InputAction.CallbackContext callback)
    {
        ControllerMenu();
    }

    private void ControllerMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
        inventory.SetActive(false);
    }

    public void ControllerInventory()
    {
        if(menu.activeInHierarchy)return;
        if (inventory.activeInHierarchy)
            inventory.SetActive(false);
       
        else
            inventory.SetActive(true);
    }
    private void BackToMenu()
    {
        DontDestroyManager.instance.ClearAll();
        SceneManager.LoadScene("MainMenu");
    }
}
