using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool hit = false; 
  //  public float speed = 15f;
  //  public float mapWidth = 5f;

    public int laneNumber = 0;
    public int lanesCount = 4;
    bool didChangeLastFrame = false;
    public float laneDistance = 1;
    public float firstLaneXPos = 0;
    public float deadZone = 0.1f;
    public float sideSpeed = 5;

    //Rigibody access 
    private Rigidbody2D rb;

    void Start()
    {
        //Finds rigidbody and calls it rb 
        rb = GetComponent<Rigidbody2D>();
    }

    //Fixed keyboard movement
    void Update()
    {
    
            //"Horizontal" is a default input axis set to arrow keys and A/D
            //We want to check whether it is less than the deadZone instead of whether it's equal to zero 
            float input = Input.GetAxis("Horizontal");
            if (Mathf.Abs(input) > deadZone)
            {
                if (!didChangeLastFrame)
                {
                    didChangeLastFrame = true; //Prevent overshooting lanes
                    laneNumber += Mathf.RoundToInt(Mathf.Sign(input));
                    if (laneNumber < 0) laneNumber = 0;
                    else if (laneNumber >= lanesCount) laneNumber = lanesCount - 1;
                }
            }
            else
            {
                didChangeLastFrame = false;
                //The user hasn't pressed a direction this frame, so allow changing directions next frame.
            }

            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(pos.x, firstLaneXPos + laneDistance * laneNumber, Time.deltaTime * sideSpeed);
            transform.position = pos;

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
