using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController controller;
    
    private static readonly int MovingHorizontal = Animator.StringToHash("MovingHorizontal");
    private static readonly int IsAttackingMelee = Animator.StringToHash("IsAttackingMelee");
    private static readonly int Grounded = Animator.StringToHash("Grounded");

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
    }

    public void UpdateMovingHorizontal(bool moving)
    {
        anim.SetBool(MovingHorizontal, moving);
    }

    public void AttackingMelee(bool attacking)
    {
        anim.SetBool(IsAttackingMelee, attacking);
    }

    public void UpdateGrounded(bool grounded)
    {
        anim.SetBool(Grounded, grounded);
    }

    public void Anim_OnNormalAttackFinished()
    {
        AttackingMelee(false);
        controller.Attack.SetIsAttacking(false);
    }
}