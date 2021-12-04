using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : EnemyAnimation
{
    private static readonly int Attacc = Animator.StringToHash("Attacc");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Hit = Animator.StringToHash("Hit");

    public void AttackAnim(bool shouldAttack)
    {
        anim.SetBool(Attacc, shouldAttack);
    }
    
    public void WalkAnim(bool shouldWalk)
    {
        anim.SetBool(Walk, shouldWalk);
    }
    
    public void HitAnim(bool hit)
    {
        anim.SetBool(Hit, hit);
    }
    
    public void DeadAnim()
    {
        WalkAnim(false);
        HitAnim(false);
        AttackAnim(false);
        anim.SetBool(Dead, true);
    }

    public void Anim_OnAttackFinished()
    {
        anim.SetBool(Attacc, false);
        controller.GetEnemyIA<SkeletonIA>().isAttacking = false;
    }
    
    public void Anim_OnHitEnded()
    {
        anim.SetBool(Hit, false);   
    }

    public bool IsHurt()
    {
        return anim.GetBool(Hit);
    }
}
