using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public float score = -1f;
    public float currentScore; 
    public Text scoreText;
    public static bool playerReallyHit = false; 

    private PlayerScript playerHit;

    void Start()
    {
        playerHit = GameObject.Find("Player").GetComponent<PlayerScript>();
        scoreText.text = "0";
        playerHit.hit = false; 

    }

   
    

    void OnTriggerEnter2D()
    {
        if (GameObject.FindWithTag("Block"))
        {
            score += 0.333333333f;  
            Debug.Log("HITTTTT");
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        if (score <= -1)
        {
            score = 0;
        }

        scoreText.text = "" +Mathf.Round(score);
    }
}
