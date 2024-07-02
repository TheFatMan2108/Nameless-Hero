using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    #region Animation
    public Animator animator { get; private set; }
    #endregion
    #region State
    public WeaponStateMachine stateMachine { get; private set; }
    public WeaponIdleState idleState { get; private set; }
    public WeaponAttackState attackState { get; private set; }
    #endregion
    #region Player
    public Player playerManager { get; private set; }
    #endregion
    #region Attack movement state
    public int[] attackMovement;
    #endregion
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerManager = transform.parent.GetComponentInParent<Player>();
        #region Call State
        stateMachine = new WeaponStateMachine();
        idleState = new WeaponIdleState(stateMachine,this,"Idle");
        attackState = new WeaponAttackState(stateMachine, this, "Attack");
        #endregion
    }
    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.State.Update();
    }

    public void FinishAnimation()
    {
        stateMachine.State.AnimationFinish();
    }

    public void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerManager.attackCheck.position, playerManager.attackDistance);
        foreach (var hit in colliders)
        {
            if (hit.gameObject.TryGetComponent(out Enemy enemy))
            {
                ItemEquitment item = Inventory.Instance.GetEquitment(EquitmentType.Weapon);
                if (enemy.isDead||!enemy.gameObject.activeInHierarchy)return;
                enemy.TakeDamage(playerManager.transform.position);
                enemy.entityStats.SetEnemy(playerManager);
                playerManager.entityStats.DoDamage(enemy);
                if (item == null) return;
                item.ExecuteItemEffect(enemy.transform);
                enemy.UpdateHealth();
                

            }
        }
    }
}
