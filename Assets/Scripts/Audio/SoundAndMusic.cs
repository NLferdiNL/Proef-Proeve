using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    public static SoundAndMusic instance = null;     //Allows other scripts to call functions from SoundManager.             
    public AudioClip[] Music;
    public AudioClip[] SoundEffects;

    void Awake()
    {
        Music = Resources.LoadAll<AudioClip>("Audio/Music");
        foreach (AudioClip clip in Music)
        {
            
        }
    }

}
