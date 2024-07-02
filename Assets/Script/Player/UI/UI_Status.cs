using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    private GameObject healthBar, manaBar, staminaBar;
    private Player player;
    void Start()
    {
        player = PlayerManager.Instance.player;
        healthBar = transform.GetChild(0).transform.GetChild(0).gameObject;
        manaBar = transform.GetChild(0).transform.GetChild(1).gameObject;
        staminaBar = transform.GetChild(0).transform.GetChild(2).gameObject;
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
    }
}