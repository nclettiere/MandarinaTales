using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float smoothing = .05f;
    [SerializeField] private Transform[] wallChecks;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D rBody;
    private Vector3 velocity = Vector3.zero;
    private bool facingRight = true;
    
    protected virtual void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallChecks[0].position, wallChecks[1].position);
    }

    public virtual void Move()
    {
        int directionMultiplier = facingRight ? 1 : -1;
        
        Vector3 targetVelocity = new Vector2(directionMultiplier * speed, rBody.velocity.y);
        rBody.velocity = Vector3.SmoothDamp(rBody.velocity, targetVelocity, ref velocity, smoothing);
    }
    
    public virtual void Move(float customSpeed)
    {
        int directionMultiplier = facingRight ? 1 : -1;
        
        Vector3 targetVelocity = new Vector2(directionMultiplier * customSpeed, rBody.velocity.y);
        rBody.velocity = Vector3.SmoothDamp(rBody.velocity, targetVelocity, ref velocity, smoothing);
    }
    
    public void Stop()
    {
        rBody.velocity = Vector3.zero;
    }

    public bool CheckWall()
    {
        return Physics2D.Linecast(wallChecks[0].position, wallChecks[1].position, whatIsGround);
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

    public virtual void DeadMovement()
    {
        Stop();
        rBody.constraints = RigidbodyConstraints2D.None;
        rBody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        rBody.AddTorque(1f, ForceMode2D.Force);
    }
}
