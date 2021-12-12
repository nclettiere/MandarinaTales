using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Companion : MonoBehaviour
{
    public float InteraactionRadius = 1f;
    public LayerMask WhatIsPlayer;

    private bool following;

    [SerializeField] private Animator anim;
    private static readonly int Following = Animator.StringToHash("Following");

    private Vector3 startPos;
    private bool facingRight = true;

    private ICompanionHost player;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        CheckForInteraction();
        if (following)
            FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 target = player.GetCompanionTarget();

        if (Vector3.Distance(transform.position, target) >= 0.1f &&
            Vector3.Distance(transform.position, target) >= 0.1f)
        {
            anim.SetBool(Following, true);
        }
        else
        {
            anim.SetBool(Following, false);
            return;
        }

        transform.position =
            Vector3.Lerp(transform.position, new Vector3(target.x, target.y, startPos.z), Time.deltaTime);

        var playerPos = player.GetCurrentPosition().x;

        if (transform.position.x > playerPos && facingRight)
            Flip();
        else if (transform.position.x < playerPos && !facingRight)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, InteraactionRadius);
    }

    public void CheckForInteraction()
    {
        if (!following)
        {
            var hit = Physics2D.OverlapCircle(transform.position, InteraactionRadius, WhatIsPlayer);
            if (hit != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    player = hit.transform.GetComponent<ICompanionHost>();
                    //if(hit.transform is ICompanion)
                    //    player = hit.transform as ICompanion;
                    
                    anim.SetBool(Following, true);
                    following = true;
                }
            }
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