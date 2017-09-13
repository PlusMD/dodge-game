using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private List<Vector3> touchPositions = new List<Vector3>(); //store all the touch positions in list


    void Start()
    {
        dragDistance = Screen.height * 20 / 100; //dragDistance is 20% height of the screen 
    }

    void Update()
    {

        foreach (Touch touch in Input.touches)  //use loop to detect more than one swipe
        { //can be ommitted if you are using lists 
          /*if (touch.phase == TouchPhase.Began) //check for the first touch
          {
              fp = touch.position;
              lp = touch.position;

          }*/

            if (touch.phase == TouchPhase.Moved) //add the touches to list as the swipe is being made
            {
                touchPositions.Add(touch.position);
            }

            if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                //lp = touch.position;  //last touch position. Ommitted if you use list
                fp = touchPositions[0]; //get first touch position from the list of touches
                lp = touchPositions[touchPositions.Count - 1]; //last touch position 

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal 
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height

            }
        }
    }



}
