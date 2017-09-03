using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject blockPrefab;

    private float spawnTimer = 2f;
    public float waveTimer = 1f;

    public float waveScore = 0f; 

    void Update()
    {
        if (Time.time >= spawnTimer)
        {
            spawnBlocks();
            spawnTimer = Time.time + waveTimer;
            waveScore += 1; 
        }
    }


	void spawnBlocks ()
	{

	    int randomIndex = Random.Range(0, spawnPoints.Length);

	    for (int i = 0; i < spawnPoints.Length; i++)
	    {
	        if (randomIndex != i)
	        {
	            Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity); 
	        }
	    }

	}

}
