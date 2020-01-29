using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager 
{

    public void Start()
    {
        
    }

    public enum Sound
    {
       
    }
    public  void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private  AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }

        }
        return null;
    }
}
