using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score = -1f; 

    


    void OnTriggerEnter2D()
    {
        if (GameObject.FindWithTag("Block"))
        {
            score += 0.333333333333f;
            Debug.Log("HITTTTT");
        }
    }
}
