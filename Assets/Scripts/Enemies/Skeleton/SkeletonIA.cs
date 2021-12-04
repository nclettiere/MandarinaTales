using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIA : EnemyIA
{
    public bool isAttacking;
    private SkeletonAnimation anim;

    public override void Start()
    {
        base.Start();
        anim = controller.GetEnemyAnimator<SkeletonAnimation>();
    }

    public override void OnUpdate()
    {
        if (!anim.IsHurt())
        {
            if (controller.CheckPlayerInNearRange() && !isAttacking)
            {
                anim.AttackAnim(true);
                anim.WalkAnim(false);
                controller.enemyMovement.Stop();
                isAttacking = true;
            }
            else if (!isAttacking)
            {
                anim.WalkAnim(true);
                anim.AttackAnim(false);
                controller.enemyMovement.Move();

                if (controller.enemyMovement.CheckWall())
                    controller.enemyMovement.Flip();
            }
        }
        else
        {
            controller.enemyMovement.Stop();
        }
    }
}
