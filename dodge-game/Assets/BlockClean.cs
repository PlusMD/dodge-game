using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClean : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(transform.position.y < -2f)
		{
		    Destroy(gameObject); 
		}
	}
}
