using Managers;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntegridadEscenas
{
    [Test]
    public void IntegridadPrincipal()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MenuPrincipal.unity");
        
        var uiManager    = GameObject.FindObjectOfType<UIManager>();
        var worldManager = GameObject.FindObjectOfType<WorldManager>();
        var soundManager = GameObject.FindObjectOfType<SoundManager>();
        var eventSystem  = GameObject.FindObjectOfType<EventSystem>();
        var camera       = GameObject.FindObjectOfType<Camera>();
        var playerDummy  = GameObject.FindObjectOfType<PlayerDummy>();
        
        Assert.NotNull(uiManager, "Error, La escena no cuenta con un UIManager");
        Assert.NotNull(worldManager, "Error, La escena no cuenta con un WorldManager");
        Assert.NotNull(soundManager, "Error, La escena no cuenta con un SoundManager");
        Assert.NotNull(eventSystem, "Error, La escena no cuenta con un EventSystem");
        Assert.NotNull(camera, "Error, La escena no cuenta con un Camera");
        Assert.NotNull(playerDummy, "Error, La escena no cuenta con un PlayerDummy");
    }
    
    [Test]
    public void IntegridadNivel1()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Nivel1.unity");
        
        var gameManager   = GameObject.FindObjectOfType<GameManager>();
        var playerManager = GameObject.FindObjectOfType<PlayerManager>();
        var uiManager     = GameObject.FindObjectOfType<UIManager>();
        var worldManager  = GameObject.FindObjectOfType<WorldManager>();
        var inputManager  = GameObject.FindObjectOfType<InputManager>();
        var soundManager  = GameObject.FindObjectOfType<SoundManager>();
        var eventSystem   = GameObject.FindObjectOfType<EventSystem>();
        var camera        = GameObject.FindObjectOfType<Camera>();
        
        Assert.NotNull(gameManager, "Error, La escena no cuenta con un GameManager");
        Assert.NotNull(playerManager, "Error, La escena no cuenta con un PlayerManager");
        Assert.NotNull(uiManager, "Error, La escena no cuenta con un UIManager");
        Assert.NotNull(worldManager, "Error, La escena no cuenta con un WorldManager");
        Assert.NotNull(inputManager, "Error, La escena no cuenta con un InputManager");
        Assert.NotNull(soundManager, "Error, La escena no cuenta con un SoundManager");
        Assert.NotNull(eventSystem, "Error, La escena no cuenta con un EventSystem");
        Assert.NotNull(camera, "Error, La escena no cuenta con un Camera");
    }
    
    [Test]
    public void IntegridadGameOver()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GameOver.unity");
        
        var gameManager   = GameObject.FindObjectOfType<GameManager>();
        var playerManager = GameObject.FindObjectOfType<PlayerManager>();
        var worldManager  = GameObject.FindObjectOfType<WorldManager>();
        var inputManager  = GameObject.FindObjectOfType<InputManager>();
        var soundManager  = GameObject.FindObjectOfType<SoundManager>();
        var eventSystem   = GameObject.FindObjectOfType<EventSystem>();
        var camera        = GameObject.FindObjectOfType<Camera>();
        
        Assert.NotNull(gameManager, "Error, La escena no cuenta con un GameManager");
        Assert.NotNull(playerManager, "Error, La escena no cuenta con un PlayerManager");
        Assert.NotNull(worldManager, "Error, La escena no cuenta con un WorldManager");
        Assert.NotNull(inputManager, "Error, La escena no cuenta con un InputManager");
        Assert.NotNull(soundManager, "Error, La escena no cuenta con un SoundManager");
        Assert.NotNull(eventSystem, "Error, La escena no cuenta con un EventSystem");
        Assert.NotNull(camera, "Error, La escena no cuenta con un Camera");
    }
    
    [Test]
    public void IntegridadLevelWon()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/LevelWon.unity");
        
        var gameManager   = GameObject.FindObjectOfType<GameManager>();
        var playerManager = GameObject.FindObjectOfType<PlayerManager>();
        var worldManager  = GameObject.FindObjectOfType<WorldManager>();
        var inputManager  = GameObject.FindObjectOfType<InputManager>();
        var soundManager  = GameObject.FindObjectOfType<SoundManager>();
        var eventSystem   = GameObject.FindObjectOfType<EventSystem>();
        var camera        = GameObject.FindObjectOfType<Camera>();
        
        Assert.NotNull(gameManager, "Error, La escena no cuenta con un GameManager");
        Assert.NotNull(playerManager, "Error, La escena no cuenta con un PlayerManager");
        Assert.NotNull(worldManager, "Error, La escena no cuenta con un WorldManager");
        Assert.NotNull(inputManager, "Error, La escena no cuenta con un InputManager");
        Assert.NotNull(soundManager, "Error, La escena no cuenta con un SoundManager");
        Assert.NotNull(eventSystem, "Error, La escena no cuenta con un EventSystem");
        Assert.NotNull(camera, "Error, La escena no cuenta con un Camera");
    }
}