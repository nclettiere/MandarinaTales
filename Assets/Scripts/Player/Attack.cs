using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject distanceAttack;
    [SerializeField] private Transform meleeAttackPostion, distanceAttackPosition;
    [SerializeField] private float meleeAttackRadius = 0.2f;
    [SerializeField] private LayerMask whatIsEnemy;
    private PlayerController controller;
    private bool isAttacking, canCheckForDamage;
    public bool CanUsePowerUp;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (canCheckForDamage)
        {
            DoDamage();
        }
    }

    public void DoDamage()
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
    
    public void DoDistanceAttack()
    {
        if (controller.died || !CanUsePowerUp) return;

        if (!isAttacking && controller.Movement.grounded)
        {
            controller.Anim.AttackingDistance(true);
            isAttacking = true;
        }
    }
    
    public void SpawnProjectile()
    {
        Quaternion rotation = controller.Movement.facingRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        Instantiate(distanceAttack, distanceAttackPosition.position, rotation);
    }
    
    public void DamageCheck()
    {
        canCheckForDamage = true;
    }

    public void SetIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
        if(!isAttacking)
            canCheckForDamage = false;
    }
}