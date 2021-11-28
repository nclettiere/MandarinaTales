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
            StopCoroutine(CancelComboContinuity());
            
            if (comboN == 0)
            {
                controller.Anim.AttackingMelee(true, 0);
                comboN = 1;
                isAttacking = true;
            }
            else if (comboN == 1)
            {
                controller.Anim.AttackingMelee(true, 1);
                comboN = 0;
                isAttacking = true;
            }
        }
    }

    public void Anim_OnNormalAttackFinished()
    {
        controller.Anim.AttackingMelee(false);
        isAttacking = false;

        if (comboN == 1)
        {
            StartCoroutine(CancelComboContinuity());
        }
    }

    private IEnumerator CancelComboContinuity()
    {
        yield return new WaitForSeconds(2);
        comboN = 0;
        yield return 0;
    }
}
