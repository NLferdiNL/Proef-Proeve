using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    public Slider slider;

    public void SlideAudio()
    {
        AudioListener.volume = slider.value;
    }
}
