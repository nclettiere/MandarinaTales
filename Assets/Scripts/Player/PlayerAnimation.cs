using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController controller;
    
    private static readonly int MovingHorizontal = Animator.StringToHash("MovingHorizontal");
    private static readonly int IsAttackingMelee = Animator.StringToHash("IsAttackingMelee");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int Died = Animator.StringToHash("Died");
    private static readonly int DistanceAttack = Animator.StringToHash("DistanceAttack");

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
    
    public void AttackingDistance(bool isAttackingDistance)
    {
        AttackingMelee(false);
        anim.SetBool(DistanceAttack, isAttackingDistance);
    }

    public void UpdateGrounded(bool grounded)
    {
        if (anim == null) return;
        if(!anim.GetBool(IsAttackingMelee) && !anim.GetBool(Hurt))
            anim.SetBool(Grounded, grounded);
    }
    
    public void PlayerHurt(bool hurt)
    {
        if(!anim.GetBool(IsAttackingMelee) && anim.GetBool(Grounded))
            anim.SetBool(Hurt, hurt);
    }

    public void Anim_OnNormalAttackFinished()
    {
        AttackingMelee(false);
        controller.Attack.SetIsAttacking(false);
    }
    
    public void Anim_OnDistanceAttackFinished()
    {
        AttackingDistance(false);
        controller.Attack.SetIsAttacking(false);
    }
    
    public void Anim_OnHurtEnd()
    {
        PlayerHurt(false);
    }

    public void PlayerDied()
    {
        PlayerHurt(false);
        UpdateGrounded(true);
        AttackingMelee(false);
        UpdateMovingHorizontal(false);
        anim.SetBool(Died, true);
    }

}