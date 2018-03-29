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

    private int pickSfx;
    private int Pick;


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
    }

    public void PlayMusic(int pickMus)
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        AudioListener.volume = VolumeSlider.HoldVolume;
        BackgroundMusic.clip = Music[pickMus];
        BackgroundMusic.Play();
    }

    public void PlaySfx()
    {
        RandomSfx();
        SoundEffectOne.clip = SoundEffects[pickSfx];
        SoundEffectOne.Play();
    }
    public void RandomSfx()
    {
        Pick = Random.Range(0, SoundEffects.Length);
        pickSfx = Pick;
    }
}
