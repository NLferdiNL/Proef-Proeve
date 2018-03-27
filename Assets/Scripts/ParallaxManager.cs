using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{

    [SerializeField]
    private float xRot, yRot = 0;

    private Vector3 _gyroRotationRate;

    private static ParallaxManager instance;

    public static float XRot
    {
        get
        {
            return instance.xRot;
        }
    }

    public static float YRot
    {
        get
        {
            return instance.yRot;
        }
    }

    private void Start()
    {
        instance = this;
        if (!SystemInfo.supportsGyroscope)
            enabled = false;
    }

    private void FixedUpdate()
    {
        _gyroRotationRate = Input.gyro.rotationRate;
    }
}
