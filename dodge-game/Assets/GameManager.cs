using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float slomo = 10f; 

    public void EndGame()
    {
        StartCoroutine(RestartLevel()); 
        Debug.Log("ENDING GAME");
    }

    IEnumerator RestartLevel()
    {
        //When adjusting time, you ahve to use fixed delta time to make it smooth boy 
        //Slomo
        Time.timeScale = 1f / slomo;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slomo; 


        //Before
        yield return new WaitForSeconds(1f / slomo);
        //After

        //Reset slomo
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slomo;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
	
