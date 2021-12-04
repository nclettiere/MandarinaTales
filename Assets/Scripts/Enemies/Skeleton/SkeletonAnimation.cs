using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : EnemyAnimation
{
    private static readonly int Attacc = Animator.StringToHash("Attacc");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Hit = Animator.StringToHash("Hit");
    private static readonly int Dead1 = Animator.StringToHash("Dead");

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
        anim.SetBool(Dead1, true);
    }

    public void Anim_OnAttackFinished()
    {
        anim.SetBool(Attacc, false);   
    }
    
    public void Anim_OnHitEnded()
    {
        anim.SetBool(Hit, false);   
    }
}
