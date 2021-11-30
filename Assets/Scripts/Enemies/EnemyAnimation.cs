using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator anim;
    protected EnemyController controller;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<EnemyController>();
    }
}
