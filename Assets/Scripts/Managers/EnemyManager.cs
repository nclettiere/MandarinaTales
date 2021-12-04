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
    public UnityEvent OnAllEnemiesSlain; 
        
    private Queue<EnemyController> enemies;

    private void Awake()
    {
        if (OnAllEnemiesSlain == null)
            OnAllEnemiesSlain = new UnityEvent();
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (var pos in EnemySpawners)
        {
            int random = Random.Range(0, EnemyTypes.Length);
            Instantiate(EnemyTypes[random], pos.position, Quaternion.identity, transform);
        }
    }
}
