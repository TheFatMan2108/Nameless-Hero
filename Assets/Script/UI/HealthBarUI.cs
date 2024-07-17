using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    protected Enemy entity;
    protected Slider healthBar;
    protected EntityStats myStats;
    public float timeHideBar = 10;
    protected float currentTimer;
    protected virtual void Start(){}
    protected virtual void Update() { currentTimer-=Time.deltaTime; }
    public virtual void UpdateHealth() { }
    protected virtual void OnHealthBar() { }
    protected virtual void OffHealthBar() { }
    protected virtual void Fliped(float xInput) { }
    protected virtual void OnDisable() { }
}
