using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenMode : MonoBehaviour
{
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
