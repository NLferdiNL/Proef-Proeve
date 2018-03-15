using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    //Public Variables
    [SerializeField] private GameObject player;
    //A modifier which affects the rackets speed
    [SerializeField] private float speed;
    //Fraction defined by user that will limit the touch area
    [SerializeField] private int frac;

    //Private Variables
    private float fracScreenWidth;
    private float widthMinusFrac;
    private Vector2 touchCache;
    private Vector3 playerPos;
    private bool touched = false;
    private int screenHeight;
    private int screenWidth;
    // Use this for initialization
    void Start()
    {
        //Cache called function variables
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        fracScreenWidth = screenWidth / frac;
        widthMinusFrac = screenWidth - fracScreenWidth;
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If running game in editor
#if UNITY_EDITOR
         //If mouse button 0 is down
         if(Input.GetMouseButton(0))
         {
             //Cache mouse position
             Vector2 mouseCache = Input.mousePosition;
             //If mouse x position is less than or equal to a fraction of the screen width
             if (mouseCache.x <= fracScreenWidth)
             {
                 //playerPos = new Vector3(-7.5f, 0.5f, Mathf.Clamp(mouseCache.y / screenHeight * speed, 0, 8));
             }
             //Set touched to true to allow transformation
             touched = true;
         }
#endif
        //If a touch is detected
        if (Input.touchCount >= 1)
        {
            //For each touch
            foreach (Touch touch in Input.touches)
            {
                //Cache touch position
                touchCache = touch.position;
                //If touch x position is less than or equal to a fraction of the screen width
                if (touchCache.x <= fracScreenWidth)
                {
                    //playerPos = new Vector3(-7.5f, 0.5f, Mathf.Clamp(touchCache.y / screenHeight * 8, 0, 8));
                }
            }
            touched = true;
        }
    }

    //FixedUpdate is called once per fixed time step
    void FixedUpdate()
    {
        if (touched)
        {
            //Transform rackets
            player.transform.position = playerPos;
            touched = false;
        }
    }
}
