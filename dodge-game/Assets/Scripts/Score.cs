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

   //private PlayerScript playerHit;

    void Start()
    {
        //Start the game with the text displaying 0
        scoreText.text = "0";

        //playerHit = GameObject.Find("Player").GetComponent<PlayerScript>();
        //playerHit.hit = false; 

    }

   
    

    void OnTriggerEnter2D()
    {
        //When a block hits the score point add score
        if (GameObject.FindWithTag("Block"))
        {
            score += 0.333333333f;  
            Debug.Log("HITTTTT");
            //Run update score
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        //Makes sure no minus scores can display
        if (score <= -1)
        {
            score = 0;
        }
        //Round the score to ensure no .333 scores show when hitting a block.
        scoreText.text = "" +Mathf.Round(score);
    }
}
