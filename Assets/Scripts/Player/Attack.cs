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
        var hits =
            Physics2D.CircleCastAll(meleeAttackPostion.position, meleeAttackRadius, Vector2.right, 0, whatIsEnemy);
        foreach (var hit in hits)
        {
            if (hit.transform.CompareTag("Enemy"))
                hit.transform.SendMessage("Damage", 4);
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