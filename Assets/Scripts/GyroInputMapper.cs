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

        if (Input.gyro.enabled)
        {
            _gyroState = true;
            Debug.Log("yay it works");
        }
        else
        {
            Debug.Log("This device may not have a Gyro");
            _gyroState = false;
            Input.gyro.enabled = true;
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
    // Update is called once per frame
    void Update()
    {
        _gyroRotationRate = Input.gyro.rotationRate;
    }
}
