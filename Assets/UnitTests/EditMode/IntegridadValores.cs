using CameraManagement;
using Managers;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntegridadValores
{
    [Test]
    public void MainMenu()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MenuPrincipal.unity");
        
        var uiManager    = GameObject.FindObjectOfType<UIManager>();
        var soundManager = GameObject.FindObjectOfType<SoundManager>();
        
        Assert.NotNull(uiManager.pauseMenu);
        Assert.NotNull(uiManager.optionsMenu);
        Assert.AreNotSame(uiManager.pauseMenu, uiManager.optionsMenu);
        Assert.True(uiManager.IsMainMenu);
        
        Assert.NotNull(soundManager.LevelMusicSource);
        Assert.NotNull(soundManager.LevelMusicClip);
        Assert.True(soundManager.IsMainMenu);
    }
    
    [Test]
    public void Nivel1()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Nivel1.unity");
        
        var gameManager   = GameObject.FindObjectOfType<GameManager>();
        var playerManager = GameObject.FindObjectOfType<PlayerManager>();
        var enemyManager  = GameObject.FindObjectOfType<EnemyManager>();
        var uiManager     = GameObject.FindObjectOfType<UIManager>();
        var soundManager  = GameObject.FindObjectOfType<SoundManager>();
        var eventSystem   = GameObject.FindObjectOfType<EventSystem>();
        var camera        = GameObject.FindObjectOfType<DynamicCamera>();
        
        Assert.NotNull(gameManager.enemyManager);
        Assert.NotNull(gameManager.playerManager);
        Assert.NotNull(gameManager.uiManager);
        Assert.NotNull(gameManager.worldManager);
        Assert.NotNull(gameManager.inputManager);
        Assert.NotNull(gameManager.soundManager);
        Assert.False(gameManager.isGamePaused);
        
        Assert.False(enemyManager.EnemySpawners.Length == 0);
        Assert.False(enemyManager.EnemyTypes.Length == 0);
        
        Assert.NotNull(playerManager.playerPrefab);
        Assert.NotNull(playerManager.powerUpIndicator);
        Assert.NotNull(playerManager.dynamicCamera);
        
        Assert.NotNull(uiManager.pauseMenu);
        Assert.NotNull(uiManager.optionsMenu);
        Assert.AreNotSame(uiManager.pauseMenu, uiManager.optionsMenu);
        Assert.False(uiManager.IsMainMenu);
        
        Assert.NotNull(soundManager.LevelMusicSource);
        Assert.NotNull(soundManager.LevelMusicClip);
        Assert.False(soundManager.IsMainMenu);
        
        Assert.NotNull(camera);
        Assert.NotNull(eventSystem);
    }
    
    [Test]
    public void GameOver()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GameOver.unity");
        
        var gameManager   = GameObject.FindObjectOfType<GameManager>();
        
        Assert.NotNull(gameManager.enemyManager);
        Assert.NotNull(gameManager.playerManager);
        Assert.NotNull(gameManager.worldManager);
        Assert.NotNull(gameManager.inputManager);
        Assert.NotNull(gameManager.soundManager);
        Assert.False(gameManager.isGamePaused);
    }    
    
    [Test]
    public void LevelWon()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/LevelWon.unity");
        var gameManager = GameObject.FindObjectOfType<GameManager>();
        
        Assert.NotNull(gameManager.enemyManager);
        Assert.NotNull(gameManager.playerManager);
        Assert.NotNull(gameManager.worldManager);
        Assert.NotNull(gameManager.inputManager);
        Assert.NotNull(gameManager.soundManager);
        Assert.False(gameManager.isGamePaused);
    }
}
