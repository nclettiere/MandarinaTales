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

    void Start()
    {
        Attack = GetComponent<Attack>();
        Movement = GetComponent<Movement>();
        Anim = GetComponent<PlayerAnimation>();
        
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public Vector3 GetCompanionTarget()
    {
        return CompanionTarget.position;
    }
    
    public void Damage(int amount)
    {
        if (Time.time >= damageCooldownTime)
        {
            currentHealth -= amount;
    
            if (currentHealth <= 0)
            {
                Die();
            }
            
            damageCooldownTime = Time.time + damageCooldown;
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
