using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    private GameObject healthBar, manaBar, staminaBar,levelText,expBar,coin;
    private Player player;
    void Start()
    {
        player = PlayerManager.Instance.player;
        expBar = transform.GetChild(0).gameObject;
        healthBar = transform.GetChild(1).transform.GetChild(0).gameObject;
        manaBar = transform.GetChild(1).transform.GetChild(1).gameObject;
        staminaBar = transform.GetChild(1).transform.GetChild(2).gameObject;
        levelText = transform.GetChild(1).transform.GetChild(3).gameObject;
        coin = transform.GetChild(1).transform.GetChild(4).gameObject;
        SetStatus();
    }

    private void SetStatus()
    {
        healthBar.GetComponent<Slider>().maxValue = player.entityStats.GetMaxHealth();
        manaBar.GetComponent<Slider>().maxValue = player.entityStats.GetMaxMana();
        staminaBar.GetComponent<Slider>().maxValue = player.entityStats.GetMaxStamina();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthBar.GetComponent<Slider>().value = player.entityStats.curentHeatlth;
        manaBar.GetComponent<Slider>().value = player.entityStats.curentMana;
        staminaBar.GetComponent<Slider>().value = player.entityStats.curentStamina;
        levelText.GetComponent<TMP_Text>().text = player.levelSystem.level.ToString();
        expBar.GetComponent<Image>().fillAmount = player.levelSystem.exp / player.levelSystem.expNextLevel;
    }
    public void TestUplevel()
    {
        PlayerManager.Instance.player.levelSystem.AddExp(200);
    }
}
