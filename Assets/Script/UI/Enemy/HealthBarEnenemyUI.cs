using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnenemyUI : HealthBarUI
{
    

    protected override void Start()
    {
        base.Start();
        entity = GetComponentInParent<Enemy>();
        healthBar = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<EntityStats>();
        entity.OnFliped += Fliped;
        entity.changeHealth += UpdateHealth;
        entity.hideBar += OffHealthBar;
        healthBar.gameObject.SetActive(false);
        currentTimer = timeHideBar;
    }

    protected override void Update()
    {
        base.Update();
        currentTimer -= Time.deltaTime;
        if (currentTimer < 0)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    public override void UpdateHealth()
    {
        base.UpdateHealth();
        if (healthBar.value > 0) OnHealthBar();

        currentTimer = timeHideBar;
        healthBar.maxValue = myStats.GetMaxHealth();
        healthBar.value = myStats.curentHeatlth;
    }

    protected override void OnHealthBar()
    {
        base.OnHealthBar();
        healthBar.gameObject.SetActive(true);
    }

    protected override void OffHealthBar()
    {
        base.OffHealthBar();
        currentTimer = 0;
        healthBar.gameObject.SetActive(false);
        Debug.Log("D chet");
    }

    protected override void Fliped(float xInput)
    {
        base.Fliped(xInput);
        if (xInput > 0) healthBar.direction = Slider.Direction.LeftToRight;
        else if (xInput < 0) healthBar.direction = Slider.Direction.RightToLeft;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        entity.OnFliped -= Fliped;
        entity.changeHealth -= UpdateHealth;
        entity.hideBar -= OffHealthBar;
    }
}
