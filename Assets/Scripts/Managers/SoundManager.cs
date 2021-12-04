using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource LevelMusicSource;
    public AudioClip LevelMusicClip;
    
    public float MasterVolume = 1;

    private void Start()
    {
        LevelMusicSource.clip = LevelMusicClip;
        LevelMusicSource.loop = true;
        LevelMusicSource.volume = MasterVolume;
        LevelMusicSource.Play();
    }

    public void PlayAtLocation(Vector3 position, AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, position, MasterVolume);
    }
}
