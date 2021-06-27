using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private bool movingDown;
    [SerializeField]
    private Transform origin;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 1.5f; 

    public void CallElevator()
    {
        movingDown = !movingDown; 
    }

    private void FixedUpdate() // smooth stepping 
    {
        // going down = true 
        // position = MoveTowards target pos 
        // else 
        // reverse 
        // current pos = MoveTowards target 

        if(movingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); 
        }
        else if(movingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin.transform.position, speed * Time.deltaTime);
        }
    }
}
