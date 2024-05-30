using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    Entity entity;
    Slider healthBar;
    EntityStats myStats;
    public float timeHideBar = 10;
    float currentTimer;
    private void Start()
    {
        entity = GetComponentInParent<Entity>();
        healthBar = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<EntityStats>();
        entity.OnFliped += Fliped;
        entity.changeHealth += UpdateHealth;
        entity.hideBar += OffHealthBar;
        healthBar.gameObject.SetActive(false);
        currentTimer = timeHideBar;
    }
    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer < 0)
        {
            healthBar.gameObject.SetActive(false);
        }
    }
    public void UpdateHealth()
    {
        OnHealthBar();
        currentTimer = timeHideBar;
        healthBar.maxValue = myStats.GetMaxHealth();
        healthBar.value = myStats.curentHeatlth;
    }
    private void OnHealthBar() => healthBar.gameObject.SetActive(true);
    private void OffHealthBar()
    {
        healthBar.gameObject.SetActive(false);

    }
    private void Fliped(float xInput)
    {
        if (xInput>0) healthBar.direction =Slider.Direction.LeftToRight;
        else if(xInput<0) healthBar.direction = Slider.Direction.RightToLeft;
    }
    private void OnDisable()
    {
        entity.OnFliped -= Fliped;
        entity.changeHealth -= UpdateHealth;
        entity.hideBar -= OffHealthBar;
    }
}