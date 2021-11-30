using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 50;
    public float damageCooldown = 1;
    [SerializeField] private Transform[] playerDetectionCheck;
    [SerializeField] private LayerMask whatIsPlayer;

    public EnemyIA enemyIA;
    public EnemyAnimation enemyAnimation;
    public EnemyMovement enemyMovement;

    private int currentHealth;
    private float damageCooldownTime = float.NegativeInfinity;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        enemyIA.OnUpdate();
    }
    
    protected virtual void FixedUpdate()
    {
        enemyIA.OnPhysicsUpdate();
    }

    protected virtual void OnDrawGizmos()
    {
        // Near Range
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerDetectionCheck[0].position, playerDetectionCheck[1].position);
        
        // Long Range
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerDetectionCheck[1].position, playerDetectionCheck[2].position);
    }

    public bool CheckPlayerInLongRange()
    {
        return Physics2D.Linecast(playerDetectionCheck[1].position, playerDetectionCheck[2].position, whatIsPlayer);
    }
    
    public bool CheckPlayerInNearRange()
    {
        return Physics2D.Linecast(playerDetectionCheck[0].position, playerDetectionCheck[1].position, whatIsPlayer);
    }
    
    public T GetEnemyAnimator<T>() where T : EnemyAnimation
    {
        return enemyAnimation as T;
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
