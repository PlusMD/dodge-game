using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public bool hit = false; 
    public float speed = 15f;
    public float mapWidth = 5f;
   //public Text scoreText;

   // private Vector3 firstTouchPoint;
   // private Vector3 lastTouchPoint;
   //private float dragDistanceMin; //Min distance for the swipe to work 

    //Rigibody access 
    private Rigidbody2D rb;

    void Start()
    {
        //Finds rigidbody and calls it rb 
        rb = GetComponent<Rigidbody2D>();

        //15% of the screen
       // dragDistanceMin = Screen.height * 15 / 100; 
    }

    /*
    void Update()
    {
        //If the user is touching the screen with a single touch
        if (Input.touchCount == 1)
        {
            //Get the first touch
            Touch touch = Input.GetTouch(0);

            //Check the touch
            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPoint = touch.position;
                lastTouchPoint = touch.position; 
            }
            //Update the last point based on where the touch moved to 
            else if (touch.phase == TouchPhase.Moved)
            {
                lastTouchPoint = touch.position;
            }
            //Check if the touch was removed
            else if (touch.phase == TouchPhase.Ended)
            {
                lastTouchPoint = touch.position;

                //THEN CHECK 
                //Check if the drag is greater than the set value 
                if (Mathf.Abs(lastTouchPoint.x - firstTouchPoint.x) > dragDistanceMin)
                {
                    //Left or right 
                    if ((lastTouchPoint.x > firstTouchPoint.x))
                    {
                        Debug.Log("MOVE ME RIGHT PLEASE");
                    }
                    else
                    {
                        Debug.Log("MOVE ME LEFT PLEASE");
                    }
                }
                else
                {
                    Debug.Log("TAP");
                }
            }
        }
    }*/

    //Fixed keyboard movement
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal")* Time.fixedDeltaTime * speed; //GetAxisRaw for no smoothing. 

        Vector2 newPosition = rb.position + Vector2.right * x;//Vector2.right 0y 1x *x = movement. 

        newPosition.x = Mathf.Clamp(newPosition.x, - mapWidth, mapWidth);

        rb.MovePosition(newPosition);
        hit = false; 


    }

    void OnCollisionEnter2D()
    {
        //When the player is hit with anything end the game. 
        hit = true;
        Debug.Log("hit");
        FindObjectOfType<GameManager>().EndGame();
       
    }
}
