using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

    private bool Muted;

    public void Check()
    {
        if (!Muted)
        {
            
            Muted = true;
            return;
        }
        else if (Muted)
        {

            Muted = false;
            return;
        }
    }
}
