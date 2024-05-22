using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected float distanceBetween;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
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

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceBetween);
    }
    #endregion


}
