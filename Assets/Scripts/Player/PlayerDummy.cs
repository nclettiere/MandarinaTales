using System;
using System.Collections;
using System.Collections.Generic;
using CameraManagement;
using UnityEngine;

public class PlayerDummy : MonoBehaviour, ICompanionHost
{
    public DynamicCamera cam;
    public GameObject UI;
    public SoundManager SM;
    public Transform companionTarget;
    
    private void Start()
    {
        StartCoroutine(CameraTweaks());
    }

    void FixedUpdate()
    {
        transform.position = transform.position + transform.right * 2 * Time.deltaTime;
    }

    private IEnumerator CameraTweaks()
    {
        yield return new WaitForSeconds(4);
        
        cam.UpdateOffsetX(1);
        UI.SetActive(true);
        SM.PlayLevelMusic();
        
        yield return null;
    }
    
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public Vector3 GetCompanionTarget()
    {
        return companionTarget.position;
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }
}
