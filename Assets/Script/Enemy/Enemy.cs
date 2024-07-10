using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Entity
{
    public Action changeHealth, hideBar;
    [SerializeField] protected CinemachineImpulseSource impulseSource;
    [SerializeField] protected float distanceBetween;
    [SerializeField] protected ScreenShakeProfile profile;
    [SerializeField] protected GameObject floatingText;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void Reset()
    {
        base.Reset();
    }



    #region fun
    public override void SetAttackBusy(bool busy)
    {
        base.SetAttackBusy(busy);
    }

    public override void SetVelocity(float xInput, float yInput)
    {
        base.SetVelocity(xInput, yInput);
    }

    public override void SetVelocity(Vector2 input)
    {
        base.SetVelocity(input);
    }

    public override void TakeDamage(Vector2 direction)
    {
        base.TakeDamage(direction);
        UpdateHealth();
        CameraShakeManager.instance.ScreenShakeFromProfile(profile,impulseSource);
    }
    public void SetFloatingText(string text)
    {
        GameObject fText = Instantiate(floatingText, transform.position, Quaternion.identity);
        fText.GetComponent<TMP_Text>().text = text;
    }
    public override void Dead()
    {
        base.Dead();
        hideBar();
    }

    public override void Stun(float timeStun)
    {
        base.Stun(timeStun);
        SetFloatingText("Parry");
    }

    public virtual Transform FindPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, distanceBetween);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {

                return collider.transform;
            }
        }
        return null;
    }
    public void UpdateHealth() => changeHealth();
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceBetween);
    }
    #endregion


}
