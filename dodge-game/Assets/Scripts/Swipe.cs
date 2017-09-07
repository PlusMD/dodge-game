using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    private bool tap, sLeft, sRight, isDrag;

    private Vector2 touchStart, swipeDelta;

    private void Update()
    {
        //Reset every frame 
        tap = sLeft = sRight = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDrag = true; 
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrag = false; 
            Reset();
        }

        #endregion

        #region Mobile Inputs

        //Is there any touches?
        if (Input.touches.Length > 0)
        {
            //Take the first touch 
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                //Set tap to true and take the location of touch 
                isDrag = true; 
                tap = true;
                touchStart = Input.touches[0].position; 
            }

            //If it has ended or canceled reset 
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDrag = false; 
                Reset();
            }
        }

        #endregion

        //CALC DISTANCE 
        swipeDelta = Vector2.zero;
      
        if (isDrag)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - touchStart;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                swipeDelta = (Vector2) Input.mousePosition - touchStart; 
            }
        }

        //Did we cross the dead zone 
        if (swipeDelta.magnitude > 125)
        {
            //What direction is the swipe 
            float x = swipeDelta.x;

            if (x < 0)
            {
                sLeft = true;
            }
            else
            {
                sRight = true; 
            }

            Reset();
        }
    }

    private void Reset()
    {
        touchStart = swipeDelta = Vector2.zero;
        isDrag = false; 
    }



    public Vector2 SwipeDelta {
        get { return swipeDelta; }
    }

    public bool SwipeLeft { 
        get{return sLeft;}
    }
    public bool SwipeRight {
        get { return sRight; }
    }



}
