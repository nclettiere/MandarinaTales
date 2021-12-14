using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, ICompanionHost
{
    public Attack Attack;
    public Movement Movement;
    public PlayerAnimation Anim;
    public int maxHealth;
    public float damageCooldown = 1;
    public Transform CompanionTarget;
    public int currentHealth;
    public GameObject powerupText;
    private float damageCooldownTime = float.NegativeInfinity;

    public UnityEvent OnPlayerDie;
    public bool died { get; private set; }

    private void Awake()
    {
        if(OnPlayerDie == null)
            OnPlayerDie = new UnityEvent();
    }

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

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public void Damage(Tuple<int, bool> options)
    {
        if (currentHealth <= 0) return;
        if (Time.time >= damageCooldownTime)
        {
            currentHealth -= options.Item1;
    
            GameManager.GM.uiManager.OnPlayerHealthChanged();
            
            if (currentHealth <= 0)
                Die();
            else
            {
                Anim.PlayerHurt(true);
                if (options.Item2)
                    Movement.DoKnockback();
                
                if(currentHealth <= 3)
                    GameManager.GM.uiManager.ShowLowHealthIndicator();
            }
            
            damageCooldownTime = Time.time + damageCooldown;
        }
    }
    
    private void Die()
    {
        OnPlayerDie.Invoke();
        died = true;
        Movement.Stop();
        Anim.PlayerDied();
    }
}
