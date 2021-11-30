using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform[] playerDetectionCheck;
    [SerializeField] private LayerMask whatIsPlayer;

    public EnemyIA enemyIA;
    public EnemyAnimation enemyAnimation;
    public EnemyMovement enemyMovement;

    private void Start()
    {
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
}
