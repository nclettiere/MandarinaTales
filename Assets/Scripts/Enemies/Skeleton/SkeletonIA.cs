using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIA : EnemyIA
{
    private bool canAttack;
    
    public override void OnUpdate()
    {
        if (controller.CheckPlayerInNearRange())
        {
            controller.GetEnemyAnimator<SkeletonAnimation>()
                .AttackAnim(true);
        }
        else
        {
            controller.enemyMovement.Move();
        }
    }
}
