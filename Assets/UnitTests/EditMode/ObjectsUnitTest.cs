using NUnit.Framework;
using UnityEngine;

public class ObjectsUnitTest
{
    [Test]
    public void  Managers()
    {
        var gameManager = GameObject.FindObjectOfType<GameManager>();
        Debug.Log($"Scene : {UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().buildIndex}");
        //if(EditorSceneManager.GetActiveScene().name != "MainMenu")
            Assert.NotNull(gameManager, "Error, La escena no cuenta con un GameManager");
    }
}