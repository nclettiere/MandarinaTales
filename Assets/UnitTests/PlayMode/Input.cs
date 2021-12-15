using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Input : InputTestFixture
{
    private static Keyboard keyboard;
    private static bool loaded;
    private static bool unloaded;

    [UnitySetUp]
    public IEnumerator SetupScene()
    {
        LogAssert.ignoreFailingMessages = true;
        loaded = false;
        SceneManager.LoadSceneAsync("Assets/Scenes/Nivel1.unity");
        SceneManager.sceneLoaded += (s, m) => loaded = true;
        yield return new WaitUntil(() => loaded);
        yield return new WaitForSeconds(1);
    }

    [UnityTest]
    public IEnumerator SimulatePause()
    {
        yield return new WaitForSeconds(1);
        if (keyboard == null)
            keyboard = InputSystem.AddDevice<Keyboard>();

        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Enable();
        PressAndRelease(keyboard.escapeKey);
        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Disable();

        yield return null;

        Assert.True(Time.timeScale == 0);

        GameManager.GM.OnPauseRequested();

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestMovementRight()
    {
        yield return new WaitForSeconds(1);
        if (keyboard == null)
            keyboard = InputSystem.AddDevice<Keyboard>();

        var player = GameObject.FindObjectOfType<PlayerController>();

        float initialpos = player.transform.position.x;

        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Enable();
        for (int i = 0; i < 1000; i++)
        {
            Press(keyboard.dKey);
            yield return null;
        }

        Release(keyboard.dKey);
        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Disable();

        yield return null;

        Assert.Greater(player.transform.position.x, initialpos);

        yield return null;
    }

    //[UnityTearDown]
    //public IEnumerator Shutdown()
    //{
    //    var objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (var o in objects)
    //    {
    //        GameObject.Destroy(o.gameObject);
    //    }
//
    //    loaded = false;
    //    SceneManager.LoadSceneAsync("Assets/Scenes/Dummy.unity");
    //    SceneManager.sceneLoaded += (s, m) => loaded = true;
    //    yield return new WaitUntil(() => loaded);
    //    yield return new WaitForSeconds(1);
    //}

    [UnityTest]
    public IEnumerator TestMovementLeft()
    {
        yield return new WaitForSeconds(1);
        if (keyboard == null)
            keyboard = InputSystem.AddDevice<Keyboard>();

        var player = GameObject.FindObjectOfType<PlayerController>();

        float initialpos = player.transform.position.x;

        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Enable();
        for (int i = 0; i < 1000; i++)
        {
            Press(keyboard.aKey);
            yield return null;
        }

        Release(keyboard.aKey);
        GameManager.GM.inputManager.controls.Gameplay.Horizontal.Disable();

        yield return null;

        Assert.Less(player.transform.position.x, initialpos);

        yield return null;
    }
}