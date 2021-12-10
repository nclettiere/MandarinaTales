using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : EnemyController
{
    [SerializeField] private AudioClip[] footsteps;
    private int currentFootstep;
    public override void Damage(int amount)
    {
        if (Time.time >= damageCooldownTime)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                GameManager.GM.soundManager.PlayAtLocation(transform.position, HitSFX);
                if (!GetEnemyIA<SkeletonIA>().isAttacking)
                    GetEnemyAnimator<SkeletonAnimation>().HitAnim(true);
            }

            damageCooldownTime = Time.time + damageCooldown;
        }
    }

    public void PlayFootstepSFX()
    {
        if (!isInvisible)
        {
            if (currentFootstep > footsteps.Length - 1)
                currentFootstep = 0;
            GameManager.GM.soundManager.PlayAtLocation(transform.position, footsteps[currentFootstep]);
            currentFootstep++;
        }
    }
}
