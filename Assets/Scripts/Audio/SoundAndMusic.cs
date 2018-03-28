using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    public static SoundAndMusic instance = null;     //Allows other scripts to call functions from SoundManager.             

    public AudioClip[] Music;
    public AudioClip[] SoundEffects;

    [SerializeField] private AudioSource BackgroundMusic;
    [SerializeField] private AudioSource SoundEffectOne;

    //public string AudioName;

    //public int PickMus; //Number in music array.
    //public int PickSfx; //Number in Sfx array.

    void Awake()
    {
        Music = Resources.LoadAll<AudioClip>("Audio/Music");
        SoundEffects = Resources.LoadAll<AudioClip>("Audio/SoundEffects");

        if (instance == null)
        {
            instance = this;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        /*
        foreach (AudioClip clip in AudioLibrary)
        {
            
        }*/
    }

    public void PlayMusic(int pickMus)
    {
        pickMus = 0;
        BackgroundMusic.clip = Music[pickMus];
        BackgroundMusic.Play();
    }

    public void PlaySfx(int pickSfx)
    {
        pickSfx = 0;
        SoundEffectOne.clip = SoundEffects[pickSfx];
        SoundEffectOne.Play();
    }
}
