using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Attack Attack;
    public Movement Movement;
    public Animation Anim;

    void Start()
    {
        Attack = GetComponent<Attack>();
        Movement = GetComponent<Movement>();
        Anim = GetComponent<Animation>();
    }

    void Update()
    {
        
    }
}
