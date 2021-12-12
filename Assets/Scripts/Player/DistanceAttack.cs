using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    public int DamageAmount = 5;
    public float Speed = 2;
    public GameObject Projectile, Impact;
    private Rigidbody2D rbody;

    private bool enemyHit;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.right * Speed;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!enemyHit)
        {
            Projectile.SetActive(false);
            Impact.SetActive(true);

            EnemyController enemy = col.GetComponent<EnemyController>();
            if (enemy != null)
            {
                rbody.velocity = Vector2.zero;
                enemyHit = true;
                enemy.SendMessage("Damage", DamageAmount);
            }
        }
    }
}