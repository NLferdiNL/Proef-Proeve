using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

    private bool Muted;

    public void Check()
    {
        if (!Muted)
        {
            AudioListener.volume = 0;
            Muted = true;
            return;
        }
        else if (Muted)
        {
            AudioListener.volume = 100;
            Muted = false;
            return;
        }
    }
}
