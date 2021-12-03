using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Attack Attack;
    public Movement Movement;
    public PlayerAnimation Anim;
    public int maxHealth;
    public float damageCooldown = 1;
    
    public Transform CompanionTarget;
    
    private int currentHealth;
    private float damageCooldownTime = float.NegativeInfinity;

    public bool died { get; private set; }

    void Start()
    {
        Attack = GetComponent<Attack>();
        Movement = GetComponent<Movement>();
        Anim = GetComponent<PlayerAnimation>();
        
        currentHealth = maxHealth;
    }

    public Vector3 GetCompanionTarget()
    {
        return CompanionTarget.position;
    }
    
    public void Damage(Tuple<int, bool> options)
    {
        if (currentHealth <= 0) return;
        if (Time.time >= damageCooldownTime)
        {
            currentHealth -= options.Item1;
    
            if (currentHealth <= 0)
                Die();
            else
            {
                Anim.PlayerHurt(true);
                if (options.Item2)
                    Movement.DoKnockback();
            }
            
            damageCooldownTime = Time.time + damageCooldown;
        }
    }
    
    private void Die()
    {
        died = true;
        Anim.PlayerDied();
    }
}
