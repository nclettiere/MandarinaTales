using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public float InteraactionRadius = 1f;
    public LayerMask WhatIsPlayer;
    
    void Start()
    {
        
    }

    void Update()
    {
        CheckForInteraction();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, InteraactionRadius);
    }

    public void CheckForInteraction()
    {
        var hit = Physics2D.OverlapCircle(transform.position, InteraactionRadius, WhatIsPlayer);
        if (hit != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("COMPANION GOOD");
            }
        }
    }
}
