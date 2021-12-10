using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemies;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 50;
    public float damageCooldown = 0.5f;
    public AudioClip HitSFX;
    public AudioClip DeathSFX;
    [SerializeField] private Transform[] playerDetectionCheck;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private bool blockIAOnInvisible = true;

    public EnemyIA enemyIA;
    public EnemyAnimation enemyAnimation;
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;

    protected int currentHealth;
    protected float damageCooldownTime = float.NegativeInfinity;

    protected bool isInvisible = true;

    public bool died { get; protected set; }
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
            if (!isInvisible)
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
        return Physics2D.Linecast(playerDetectionCheck[1].position, playerDetectionCheck[2].position, whatIsPlayer);
    }

    public bool CheckPlayerInNearRange()
    {
        return Physics2D.Linecast(playerDetectionCheck[0].position, playerDetectionCheck[1].position, whatIsPlayer);
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

    public T GetEnemyIA<T>() where T : EnemyIA
    {
        return enemyIA as T;
    }

    public virtual void Damage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }

        damageCooldownTime = Time.time + damageCooldown;
    }

    protected virtual void Die()
    {
        if (!died)
        {
            GameManager.GM.soundManager.PlayAtLocation(transform.position, DeathSFX);
            died = true;
            OnDie.Invoke();
            enemyAnimation.DeadAnim();
            enemyMovement.DeadMovement();
            Destroy(gameObject, 3);
        }
    }
}