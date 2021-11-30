using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float smoothing = .05f;
    private Rigidbody2D rBody;
    private Vector3 velocity = Vector3.zero;
    private bool facingRight = true;
    
    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        int directionMultiplier = facingRight ? 1 : -1;
        
        Vector3 targetVelocity = new Vector2(directionMultiplier * speed, rBody.velocity.y);
        rBody.velocity = Vector3.SmoothDamp(rBody.velocity, targetVelocity, ref velocity, smoothing);
    }
    
    public void Stop()
    {
        rBody.velocity = Vector3.zero;
    }
    
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void LookAtPlayer()
    {
        var playerPos = GameManager.GM.playerManager
            .GetPlayerController().transform.position.x;
        
        if (transform.position.x > playerPos && facingRight)
            Flip();
        else if (transform.position.x < playerPos && !facingRight)
            Flip();
    }
}
