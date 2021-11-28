using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static GameManager GM;

    [SerializeField] InputManager inputManager;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] EnemyManager enemyManager;


    void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;
        DontDestroyOnLoad(this);
    }

     void Start()
     {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        enemyManager = GameObject.Find("EnemiesManager").GetComponent<EnemyManager>();

    }


    public void ExitGame()
    {
        Application.Quit();
    }


}