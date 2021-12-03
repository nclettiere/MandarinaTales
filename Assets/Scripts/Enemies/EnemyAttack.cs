using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        public int BasicAttackAmount = 2;
        public Transform BasicAttackPosition;
        public float BasicAttackRadius;
        public LayerMask WhatIsPlayer;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(BasicAttackPosition.position, BasicAttackRadius);
        }

        public void DoBasicAttack()
        {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(BasicAttackPosition.position, BasicAttackRadius, WhatIsPlayer);
            foreach (var collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    if (collider.CompareTag("Player"))
                        collider.transform.SendMessage("Damage", BasicAttackAmount);
                }
            }
        }
    }
}