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
    void Start()
    {
        PlayMusic(0);
        PlaySfx(0);
    }

    public void PlayMusic(int pickMus)
    {
        BackgroundMusic.clip = Music[pickMus];
        BackgroundMusic.Play();
    }

    private void PlaySfx(int pickSfx)
    {
        SoundEffectOne.clip = SoundEffects[pickSfx];
        SoundEffectOne.Play();
    }
}
