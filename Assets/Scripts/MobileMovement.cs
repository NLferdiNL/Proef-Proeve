using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileMovement : MonoBehaviour
{
    private Vector3 touchOrigin = -Vector3.one;
    public int depth;

    // Use this for initialization
    void Start()
    {
        //
    }

    //FixedUpdate is called once per fixed time step
    void FixedUpdate()
    {
        depth = 0;
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector3 touchEnd = myTouch.position;
                float z = touchEnd.z - touchOrigin.z;

                touchOrigin.z = -1;

                depth = z > 0 ? 1 : -1;
            }
        }
    }
}