using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{

    public Swipe swipeControls;
    public Transform player;
    private Vector3 newPos;

    private void Update()
    {
        if (swipeControls.SwipeLeft)
        {
            newPos += Vector3.left;
        }
        if (swipeControls.SwipeRight)
        {
            newPos += Vector3.right;
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, newPos, 3f * Time.deltaTime); 
    }
}
