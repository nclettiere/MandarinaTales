using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public InputManager inputManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    
    void Awake()
    {
        if (GM != null)
            Destroy(GM);
        else
            GM = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}