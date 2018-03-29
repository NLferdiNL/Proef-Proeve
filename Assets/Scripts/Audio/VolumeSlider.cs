using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public Slider slider;

    private static float holdvolume;

    public static float HoldVolume
    {
        get
        {
            return holdvolume;
        } set {
            holdvolume = value;
        }
    }

    public void SlideAudio()
    {
        AudioListener.volume = slider.value;
        slider.value = HoldVolume;
    }

}
