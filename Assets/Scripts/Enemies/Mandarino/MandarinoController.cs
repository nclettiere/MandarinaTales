using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandarinoController : EnemyController
{
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
            }

            damageCooldownTime = Time.time + damageCooldown;
        }
    }
}
