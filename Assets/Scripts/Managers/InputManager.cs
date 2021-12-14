using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Controls controls;

    private void Awake()
    {
        if (controls == null)
            controls = new Controls();
    }

    private void Start()
    {
        SetupPlayerMovement();
        SetupPlayerAttack();
        SetupPause();
        
        controls.Enable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void SetupPause()
    {        
        controls.Gameplay.Pause.performed += ctx =>
        {
            GameManager.GM.OnPauseRequested();
        };
    }

    private void SetupPlayerMovement()
    {
        controls.Gameplay.Horizontal.performed += ctx =>
        {
            GameManager.GM.playerManager.GetPlayerController()
                .Movement.MoverHorizontal(ctx.ReadValue<float>());
        };
        
        controls.Gameplay.Horizontal.canceled += ctx =>
        {
            GameManager.GM.playerManager.MoverJugadorHorizontal(0);
        };
        
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
        
        controls.Gameplay.DistanceAttack.performed += ctx =>
        {
            GameManager.GM.playerManager.GetPlayerController()
                .Attack.DoDistanceAttack();
        };
    }

    public void DisableInput()
    {
        controls.Disable();
    }
    
    public void EnableInput()
    {
        controls.Enable();
    }
}