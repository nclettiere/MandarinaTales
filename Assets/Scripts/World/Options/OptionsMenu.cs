using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public bool IsMainMenu;
    public SoundManager MainMenuSoundM;
    
    private List<ResolutionEx> resolutions;
    private int currentResIndex;

    private void Start()
    {
        ObtenerResoluciones();
        
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var resolution in resolutions)
        {
            options.Add(new TMP_Dropdown.OptionData(resolution.GetDisplayName()));
        }

        resolutionDropdown.options = options;
        
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        volumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
    }

    private void ObtenerResoluciones()
    {
        Resolution[] res = Screen.resolutions;
        if (resolutions == null)
            resolutions = new List<ResolutionEx>(res.Length);

        Resolution currentRes = Screen.currentResolution;

        int i = 0;
        foreach (var resolution in res)
        {
            resolutions.Add(new ResolutionEx(resolution));
            
            if (resolution.width == currentRes.width && 
                resolution.height == currentRes.height && 
                resolution.refreshRate == currentRes.refreshRate)
                currentResIndex = i;
            i++;
        }

        if (currentResIndex != 0)
        {
            ResolutionEx item = resolutions[currentResIndex];
            resolutions.RemoveAt(currentResIndex);
            resolutions.Insert(0, item);
        }
    }

    private void OnDestroy()
    {
        resolutionDropdown.onValueChanged.RemoveListener(OnResolutionChanged);
        volumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
    }

    public void OnResolutionChanged(Int32 index)
    {
        Screen.SetResolution(resolutions[index].x, resolutions[index].y, FullScreenMode.FullScreenWindow);
    }
    
    public void OnMasterVolumeChanged(float volume)
    {
        if(!IsMainMenu)
            GameManager.GM.soundManager.UpdateMasterVolume(volume);
        else
            MainMenuSoundM.UpdateMasterVolume(volume);
    }
}

[System.Serializable]
public struct ResolutionEx
{
    public int x, y;

    public ResolutionEx(Resolution resolution)
    {
        x = resolution.width;
        y = resolution.height;
    }
    
    public string GetDisplayName()
    {
        return $"{x}x{y}";
    }
}
