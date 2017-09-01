using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void EndGame()
    {
        StartCoroutine(RestartLevel()); 
        Debug.Log("ENDING GAME");
    }

    IEnumerator RestartLevel()
    {
        //Before
        yield return new WaitForSeconds(1f);
        //After
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
	
