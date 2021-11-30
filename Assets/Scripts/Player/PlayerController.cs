using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Attack Attack;
    public Movement Movement;
    public PlayerAnimation Anim;
    
    public Transform CompanionTarget;

    void Start()
    {
        Attack = GetComponent<Attack>();
        Movement = GetComponent<Movement>();
        Anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        
    }

    public Vector3 GetCompanionTarget()
    {
        return CompanionTarget.position;
    }
}
