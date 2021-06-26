using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA, pointB; 
    [SerializeField]
    private float speed = 1f;
    private bool switchPlatform; 
    private void FixedUpdate() // fixed update is 0.2 sconds per frame physics timestamp (fixing jitter condition) 
    {
        if(switchPlatform == false)
        {
            // get current transform and MoveTowards(current pos, targetPos)  
            // destination - start 
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);
        }
        else if(switchPlatform == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);
        }
       
        // if current position == pointB
        // move to pointA 
        if(transform.position == pointB.position)
        {
            switchPlatform = true; 
        }
        else if(transform.position == pointA.position)
        {
            switchPlatform = false; 
        }
    }

    // collision detection with the player 
    // player = this object 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform; 
        }
    }

    // exit collision 
    // check if null 
    // unparent from object 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
