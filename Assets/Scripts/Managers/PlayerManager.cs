using System.Collections;
using System.Collections.Generic;
using CameraManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject powerUpIndicator;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private DynamicCamera dynamicCamera;

    private PlayerController playerController;
    
    void Start()
    {
        playerController = Instantiate(playerPrefab, transform).GetComponent<PlayerController>();
        if (dynamicCamera != null)
        {
            dynamicCamera.ChangeTarget(playerController.transform);
            dynamicCamera.FollowTarget = true;
        }

        playerController.OnPlayerDie.AddListener(() =>
        {
            GameManager.GM.worldManager.ShowGameOverScene(3);
        });
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

    public void GivePowerUp()
    {
        // indicator xdd
        Vector3 playerPos = playerController.transform.localPosition;
        Vector3 pos = new Vector3(playerPos.x + (-0.066f), playerPos.y + (-0.212f));
        Instantiate(powerUpIndicator, pos, Quaternion.identity, playerController.transform);

        playerController.Attack.CanUsePowerUp = true;
    }
}
