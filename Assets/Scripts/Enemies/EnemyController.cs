using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 50;
    public float damageCooldown = 0.25f;
    [SerializeField] private Transform[] playerDetectionCheck;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private bool blockIAOnInvisible = true;

    public EnemyIA enemyIA;
    public EnemyAnimation enemyAnimation;
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;

    private int currentHealth;
    private float damageCooldownTime = float.NegativeInfinity;
    
    private bool isInvisible = true;

    public bool died { get; private set; }
    public UnityEvent OnDie;

    private void Awake()
    {
        if (OnDie == null)
            OnDie = new UnityEvent();
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        if (died) return;
        
        if (blockIAOnInvisible)
        {
            if(!isInvisible)
                enemyIA.OnUpdate();
        }
        else
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

    private void OnBecameInvisible()
    {
        isInvisible = true;
    }

    private void OnBecameVisible()
    {
        isInvisible = false;
    }

    public bool CheckPlayerInLongRange()
    {
        var hits = Physics2D.LinecastAll(playerDetectionCheck[1].position, playerDetectionCheck[2].position);
        if (hits.Length <= 0) return false;
        return hits[0].transform.CompareTag("Player");
    }
    
    public bool CheckPlayerInNearRange()
    {
        var hits = Physics2D.LinecastAll(playerDetectionCheck[0].position, playerDetectionCheck[1].position);
        if (hits.Length <= 0) return false;
        return hits[0].transform.CompareTag("Player");
    }
    
    public bool CheckPlayerTouchDamage()
    {
        return Physics2D.Linecast(playerDetectionCheck[0].position, playerDetectionCheck[1].position, whatIsPlayer);
    }
    
    public T GetEnemyAnimator<T>() where T : EnemyAnimation
    {
        return enemyAnimation as T;
    }    
    
    public T GetEnemyMovement<T>() where T : EnemyMovement
    {
        return enemyMovement as T;
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
        died = true;
        OnDie.Invoke();
        enemyAnimation.DeadAnim();
        enemyMovement.DeadMovement();
        Destroy(gameObject, 3);
    }
}
