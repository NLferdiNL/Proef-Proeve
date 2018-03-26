using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroInputMapper : MonoBehaviour
{
    private Vector3 _gyroRotationRate;
    private bool _gyroState = false;

    private static GyroInputMapper instance;

    void Start()
    {
        instance = this;

        if (SystemInfo.supportsGyroscope)
        {
            _gyroState = true;
            Debug.Log("yay it works");
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.Log("This device may not have a Gyro");
            _gyroState = false;
        }

    }

    public static bool gyroState
    {
        get
        {
            return instance._gyroState;
        }
    }

    public static Vector3 GyroRotationRate
    {
        get
        {
            return instance._gyroRotationRate;
        }
    }
    
    void Update()
    {
        _gyroRotationRate = Input.gyro.rotationRate;
    }
}
