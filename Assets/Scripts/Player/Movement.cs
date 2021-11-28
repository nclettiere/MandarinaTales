using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float smoothing = .05f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int jumpForce = 5;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float jumpCooldown = 0.5f;
    
    private PlayerController controller;
    private Rigidbody2D rBody;
    private Vector3 velocity = Vector3.zero;
    private bool facingRight = true;

    private float horizontalMovement;
    private float jumpCooldownTime = float.NegativeInfinity;
    
    void Start()
    {
        controller = GetComponent<PlayerController>();
        rBody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
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

    public void MoverHorizontal(float movement)
    {
        horizontalMovement = movement;
        controller.Anim.UpdateVelocity(movement > 0 || movement < 0);
    }

    public void Jump()
    {
        if (Time.time >= jumpCooldownTime)
        {
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCooldownTime = Time.time + jumpCooldown;
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
