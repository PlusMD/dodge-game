using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  
    public float speed = 15f;
    public float mapWidth = 5f; 

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

        Vector2 newPosition = rb.position + Vector2.right * x;//Vector2.right 0y 1x *x = movement. 

        newPosition.x = Mathf.Clamp(newPosition.x, - mapWidth, mapWidth);

        rb.MovePosition(newPosition); 


    }

    void OnCollisionEnter2D()
    {
        Debug.Log("hit");
        FindObjectOfType<GameManager>().EndGame(); 
    }
}
