using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Speed
    public float speed = 15f;

    //Rigibody access 
    private Rigidbody2D rb;

    void Start()
    {
        //Finds rigidbody and calls it rb 
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal")* Time.fixedDeltaTime * speed; //GetAxisRaw for no smoothing. 

        rb.MovePosition(rb.position + Vector2.right * x); //Vector2.right 0y 1x *x = movement


    } 
}
