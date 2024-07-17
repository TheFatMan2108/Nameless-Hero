using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIForBoss : HealthBarUI
{
    public static HealthBarUIForBoss instance {  get; private set; }
    private TMP_Text nameBoss;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    protected override void Start()
    {
        base.Start();
        healthBar = transform.GetChild(0).GetComponentInChildren<Slider>();
        nameBoss = transform.GetChild(0).GetComponentInChildren<TMP_Text>();

    }
    protected override void Update()
    {
        base.Update();
        if (currentTimer < 0)
        {
            OffHealthBar();
        }
    }

    public override void UpdateHealth()
    {
        base.UpdateHealth();
        if (healthBar.value > 0) OnHealthBar();
        healthBar.maxValue = myStats.GetMaxHealth();
        healthBar.value = myStats.curentHeatlth;
    }

    protected override void Fliped(float xInput)
    {
        base.Fliped(xInput);
    }

    protected override void OffHealthBar()
    {
        base.OffHealthBar();
        transform.GetChild(0).gameObject.SetActive(false);

    }

    protected override void OnDisable()
    {
        base.OnDisable();
      
    }

    protected override void OnHealthBar()
    {
        base.OnHealthBar();
        transform.GetChild(0).gameObject.SetActive(true);

    }
    public void SetDataBoss(Enemy enemy)
    {
        currentTimer = timeHideBar;
        entity = enemy;
        myStats = enemy.entityStats;
        nameBoss.text = enemy.name;
        entity.OnFliped -= Fliped;
        entity.changeHealth -= UpdateHealth;
        entity.hideBar -= OffHealthBar;
        entity.OnFliped += Fliped;
        entity.changeHealth += UpdateHealth;
        entity.hideBar += OffHealthBar;
        OnHealthBar();
    }
}
