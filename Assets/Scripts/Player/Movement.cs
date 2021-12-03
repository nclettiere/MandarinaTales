using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [SerializeField] private float smoothing = .05f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int jumpForce = 5;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundedRadius = .2f;
    [SerializeField] private float jumpCooldown = 0.5f;
    
    private PlayerController controller;
    private Rigidbody2D rBody;
    private Vector3 velocity = Vector3.zero;
    private bool facingRight = true;
    public bool grounded;

    private float horizontalMovement;
    private float jumpCooldownTime = float.NegativeInfinity;
    
    public UnityEvent OnLandEvent;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    void Start()
    {
        controller = GetComponent<PlayerController>();
        rBody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (controller.died) return;
        
        CheckGroundEvent();
        
        Vector3 targetVelocity = new Vector2(horizontalMovement * speed, rBody.velocity.y);
        rBody.velocity = Vector3.SmoothDamp(rBody.velocity, targetVelocity, ref velocity, smoothing);

        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
    }

    private void CheckGroundEvent()
    {
        if (controller.died) return;
        
        controller.Anim.UpdateGrounded(grounded);
        
        bool wasGrounded = grounded;
        grounded = false;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void MoverHorizontal(float movement)
    {
        if (controller.died) return;
        horizontalMovement = movement;
        controller.Anim.UpdateMovingHorizontal(movement > 0 || movement < 0);
    }

    public void Jump()
    {
        if (controller.died) return;
        if (Time.time >= jumpCooldownTime)
        {
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCooldownTime = Time.time + jumpCooldown;
        }
    }

    public void DoKnockback()
    {
        int direction = facingRight ? -1 : 1;
        rBody.AddForce(new Vector2(10 * direction, 2), ForceMode2D.Impulse);
    }
    
    private void Flip()
    {
        if (controller.died) return;
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
