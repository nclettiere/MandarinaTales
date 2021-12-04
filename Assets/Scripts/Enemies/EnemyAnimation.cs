using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator anim;
    protected EnemyController controller;
    protected static readonly int Dead = Animator.StringToHash("Dead");

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<EnemyController>();
    }

    public virtual void DeadAnim()
    {
        anim.SetBool(Dead, true);
    }
}
