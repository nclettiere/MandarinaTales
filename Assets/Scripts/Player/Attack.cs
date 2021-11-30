using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerController controller;

    private bool isAttacking;
    private int comboN;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    public void DoNormalAttack()
    {
        if (!isAttacking)
        {
            controller.Anim.AttackingMelee(true);
            isAttacking = true;
        }
    }

    public void SetIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }
}