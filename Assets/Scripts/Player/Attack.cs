using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform meleeAttackPostion;
    [SerializeField] private float meleeAttackRadius = 0.2f;
    [SerializeField] private LayerMask whatIsEnemy;
    private PlayerController controller;
    private bool isAttacking;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    public void CheckForMeleeDamage()
    {
        if (controller.died) return;
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(meleeAttackPostion.position, meleeAttackRadius, whatIsEnemy);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                if (collider.CompareTag("Enemy"))
                    collider.transform.SendMessage("Damage", 4);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(meleeAttackPostion.position, meleeAttackRadius);
    }

    public void DoNormalAttack()
    {
        if (controller.died) return;
<<<<<<< HEAD
        
=======
>>>>>>> 110eabf (wtf)
        if (!isAttacking && controller.Movement.grounded)
        {
            controller.Anim.AttackingMelee(true);
            isAttacking = true;
        }
    }

    public void SetIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }
}