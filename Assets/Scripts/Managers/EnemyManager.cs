using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public Transform[] EnemySpawners;
    public GameObject[] EnemyTypes;
    public UnityEvent OnEnemySlain; 
    public UnityEvent OnAllEnemiesSlain; 
        
    private List<EnemyController> enemies;
    private bool hasGivenPowerUp;
    private int powerUpRandom;

    private void Awake()
    {
        enemies = new List<EnemyController>();
        
        if (OnEnemySlain == null)
            OnEnemySlain = new UnityEvent();
        if (OnAllEnemiesSlain == null)
            OnAllEnemiesSlain = new UnityEvent();
    }

    private void Start()
    {
        SpawnEnemies();

        powerUpRandom = Random.Range(0, 5);
    }

    private void SpawnEnemies()
    {
        foreach (var pos in EnemySpawners)
        {
            int random = Random.Range(0, EnemyTypes.Length);
            EnemyController controller = 
                Instantiate(EnemyTypes[random], pos.position, Quaternion.identity, transform)
                    .GetComponent<EnemyController>();
            enemies.Add(controller);
        }
    }

    public int GetEnemyCountInWorld()
    {
        return enemies.Count;
    }

    public void RemoveEnemyFromWorld(EnemyController controller)
    {
        
        if (!hasGivenPowerUp)
        {
            if (enemies.Count == 10 - powerUpRandom)
            {
                GameManager.GM.playerManager.GivePowerUp();
                hasGivenPowerUp = true;
            }
        }
        
        if(enemies.Contains(controller))
            enemies.Remove(controller);
        
        OnEnemySlain.Invoke();
        
        if(enemies.Count == 0)
            OnAllEnemiesSlain.Invoke();
    }
}
