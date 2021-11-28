using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator Anim;
    
    private static readonly int MovingHorizontal = Animator.StringToHash("MovingHorizontal");
    private static readonly int IsAttackingMelee = Animator.StringToHash("IsAttackingMelee");
    private static readonly int ComboN = Animator.StringToHash("ComboN");

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void UpdateVelocity(bool moving)
    {
        Anim.SetBool(MovingHorizontal, moving);
    }

    public void AttackingMelee(bool attacking, int comboN = 0)
    {
        Anim.SetInteger(ComboN, comboN);
        Anim.SetBool(IsAttackingMelee, attacking);
    }
}