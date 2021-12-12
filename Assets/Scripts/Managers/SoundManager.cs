using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource LevelMusicSource;
    public AudioClip LevelMusicClip;
    
    public float MasterVolume = 0.5f;
    public bool IsMainMenu;

    private void Start()
    {
        LevelMusicSource.clip = LevelMusicClip;
        LevelMusicSource.loop = true;
        LevelMusicSource.volume = MasterVolume;
        if (!IsMainMenu)
        {
            LevelMusicSource.Play();

            GameManager.GM.OnPause.AddListener(isPaused =>
            {
                if (isPaused)
                {
                    if (LevelMusicSource.isPlaying)
                        LevelMusicSource.Pause();
                }
                else
                {
                    if (!LevelMusicSource.isPlaying)
                        LevelMusicSource.Play();
                }
            });
        }
    }

    public void PlayAtLocation(Vector3 position, AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, position, MasterVolume);
    }

    public void PlayLevelMusic()
    {
        LevelMusicSource.Play();
    }
    
    public void StopLevelMusic()
    {
        LevelMusicSource.Stop();
    }    
    
    public void PauseLevelMusic()
    {
        LevelMusicSource.Pause();
    }

    public void UpdateMasterVolume(float volume)
    {
        MasterVolume = volume;
        LevelMusicSource.volume = MasterVolume;
    }
}
