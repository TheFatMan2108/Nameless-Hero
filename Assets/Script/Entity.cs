using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Stats
    public float moveSpeed;
    public float speedTemp;
    private float slowMove;
    public float attackDistance;
    public float timeStun = 0;
    [SerializeField] protected float waitEvent;
    [SerializeField] protected float knockBackDirection;
    [SerializeField] protected float knockBackTimer;
    #endregion
    #region Component
    public Animator animator;
    public Rigidbody2D rb;
    public Transform attackCheck;
    #endregion
    #region Bollean
    protected bool busy;
    public bool isKnockBack;
    public bool isDead;
    #endregion
    #region Script
    protected FXEntity fXEntity;
    public EntityStats entityStats;
    public Action<float> OnFliped;
    
    #endregion
    protected EnemyStateMachine enemyStateMachine { get; private set; }

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        fXEntity = GetComponent<FXEntity>();
        rb = GetComponent<Rigidbody2D>();
        enemyStateMachine = new EnemyStateMachine();
        entityStats = GetComponent<EntityStats>();
        isDead = false;
    }
    protected virtual void Start()
    {
        speedTemp = moveSpeed;
    }
    protected virtual void Update()
    {
       
    }
    public virtual void Flip(float dir)
    {
        transform.localScale = new Vector3 (dir, 1, 1);
        OnFliped(dir);
    }
    protected virtual void Reset()
    {
        moveSpeed = 10;
        waitEvent = 3;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void SetVelocity(float xInput, float yInput)
    {
        rb.velocity = new Vector2(xInput, yInput);
    }
    public virtual void SetVelocity(Vector2 input)
    {
        rb.velocity = input.normalized;
    }
    public virtual void SetAttackBusy(bool busy)
    {
        this.busy = busy;
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCheck.position, attackDistance);
    }

    public virtual void TakeDamage(Vector2 direction)
    {
        StartCoroutine(KnockBack(direction));
        fXEntity.StartCoroutine("HitFX");
    }
    public virtual IEnumerator KnockBack(Vector2 enemyDirection)
    {
        isKnockBack = true;
        Vector2 direction = (Vector2)transform.position - enemyDirection;
        rb.velocity = new Vector2 (direction.x*knockBackDirection, direction.y*knockBackDirection);
        yield return new WaitForSeconds(knockBackTimer);
        isKnockBack = false;
        SetVelocity(0,0);
    }

    public virtual void Dead()
    {
        isDead = true;
        
    }
    public virtual void Stun(float timeStun)
    {
        this.timeStun = timeStun;
    }
    
    public virtual void ChangeSpeed(float newSpeed,float time)
    {
        slowMove = newSpeed;
        animator.speed = GetMoveSpeed()/moveSpeed;
        StartCoroutine(ReloadSpeed(time));
    }
    private IEnumerator ReloadSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        slowMove = 0;
        animator.speed = GetMoveSpeed() / moveSpeed;
    }
    public float GetMoveSpeed() => moveSpeed-((slowMove/100)*moveSpeed);
}
