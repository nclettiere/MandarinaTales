using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public InputManager inputManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public SoundManager soundManager;
    public WorldManager worldManager;
    public UIManager uiManager;

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
        SearchManagers();
    }

    public void SearchManagers()
    {
        playerManager = GameObject.Find("/PlayerManager").GetComponent<PlayerManager>();
        inputManager = GameObject.Find("/InputManager").GetComponent<InputManager>();
        enemyManager = GameObject.Find("/EnemyManager").GetComponent<EnemyManager>();
        soundManager = GameObject.Find("/SoundManager").GetComponent<SoundManager>();
        worldManager = GameObject.Find("/WorldManager").GetComponent<WorldManager>();
        uiManager = GameObject.Find("/UIManager").GetComponent<UIManager>();
    }

    public static void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}