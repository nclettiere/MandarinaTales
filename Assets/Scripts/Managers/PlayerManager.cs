using System.Collections;
using System.Collections.Generic;
using CameraManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] DynamicCamera dynamicCamera;

    private PlayerController playerController;
    
    void Start()
    {
        playerController = Instantiate(playerPrefab, transform).GetComponent<PlayerController>();
        dynamicCamera.ChangeTarget(playerController.transform);
        dynamicCamera.FollowTarget = true;
    }

    public Transform GetPlayerTransform()
    {
        return playerPrefab.transform;
    }
    
    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    public void MoverJugadorHorizontal(float valor)
    {
        playerController.Movement.MoverHorizontal(valor);
    }
}
