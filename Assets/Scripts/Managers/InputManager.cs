using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls controls;

    private void Awake()
    {
        if (controls == null)
            controls = new Controls();
    }

    private void Start()
    {
        SetupPlayerMovement();
        SetupPlayerAttack();
        
        controls.Enable();
    }

    private void SetupPlayerMovement()
    {
        // Movimiento Horizontal
        controls.Gameplay.Horizontal.performed += ctx =>
        {
            Debug.Log("MoverHoz");
            GameManager.GM.playerManager.GetPlayerController()
                .Movement.MoverHorizontal(ctx.ReadValue<float>());
        };
        
        controls.Gameplay.Horizontal.canceled += ctx =>
        {
            GameManager.GM.playerManager.MoverJugadorHorizontal(0);
        };
        
        // Saltar
        controls.Gameplay.Jump.performed += ctx =>
        {
            GameManager.GM.playerManager.GetPlayerController()
                .Movement.Jump();
        };
    }
    
    private void SetupPlayerAttack()
    {
        controls.Gameplay.Melee.performed += ctx =>
        {
            GameManager.GM.playerManager.GetPlayerController()
                .Attack.DoNormalAttack();
        };
    }
}