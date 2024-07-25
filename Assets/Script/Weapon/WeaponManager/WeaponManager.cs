using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance { get; private set; }
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
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        playerManager = transform.parent.GetComponentInParent<Player>();
        #region Call State
        stateMachine = new WeaponStateMachine();
        idleState = new WeaponIdleState(stateMachine,this,"Idle");
        attackState = new WeaponAttackState(stateMachine, this, "Attack");
        #endregion
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
                if(item.weaponType == WeaponType.Sword)
                {
                    SwordToDamage(enemy, item);
                }else if(item.weaponType == WeaponType.Staff)
                {
                    // viet skill o day

                }
                else
                {
                    SwordToDamage(enemy, item);
                }
            }
        }
    }

    private void SwordToDamage(Enemy enemy, ItemEquitment item)
    {
        if (enemy.isDead || !enemy.gameObject.activeInHierarchy) return;
        enemy.TakeDamage(playerManager.transform.position);
        enemy.entityStats.SetEnemy(playerManager);
        playerManager.entityStats.DoDamage(enemy);
        if (item == null) return;
        item.ExecuteItemEffect(enemy.transform);
        enemy.UpdateHealth();
        GameManager.Instance.AddBattle(enemy);
    }
    private void StaffToDamage(Enemy enemy, ItemEquitment item)
    {

    }
    public void SetWeapon(ItemEquitment item)
    {
        if(item == null)
        {
            animator.SetInteger("Type", 0);
            attackMovement.SetValue(2, 0);
            attackMovement.SetValue(1, 1);
            attackMovement.SetValue(4, 2);
        }
        else
        {
            animator.SetInteger("Type", item.GetTypeWeapon(item.weaponType));
            for (int i = 0;i<item.attackMovement.Length;i++)
            {
                attackMovement.SetValue(item.attackMovement[i], i);
            }
        }
    }
}
