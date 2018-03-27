using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{

    [SerializeField]
    float depth = -1;

    [SerializeField]
    bool useZ = true;

    Vector3 startPosition;

    private void Start()
    {
        if (useZ)
            depth = transform.position.z;

        startPosition = transform.position;

		/*if (GyroInputMapper.gyroState)
            Debug.Log("Yay there is a gyro");
        else
            Debug.Log(":( no gyro -_-");*/
    }

    private void FixedUpdate()
    {
        /*if (GyroInputMapper.gyroState)
        {
            transform.position = startPosition + transform.right * GyroInputMapper.GyroRotationRate.x * depth + transform.up * GyroInputMapper.GyroRotationRate.y * depth;
        }
        else
        {*/
            transform.position = startPosition + transform.right * ParallaxManager.XRot * depth + transform.up * ParallaxManager.YRot * depth;
        //}
    }
}
