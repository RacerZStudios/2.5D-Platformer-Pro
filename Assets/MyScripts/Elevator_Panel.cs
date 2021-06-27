using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Panel : MonoBehaviour
{
    // detect trigger collision 
    // check for player 
    // if e key pressed 
    // turn light = cyan 
    [SerializeField]
    private GameObject elevatorButton;
    private int requiredCoins = 4;
    [SerializeField]
    private Elevator elevator;
    private bool elevatorCalled; 

    private void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>(); 

        if(elevator == null)
        {
            Debug.LogError("No Elevator Ref"); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && /*coin count >= 4*/ other.GetComponent<My_PlayerController>().CoinCount() >= requiredCoins)
            {
                if (elevatorCalled == true)
                {
                    // call elevator  
                    elevatorButton.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    elevatorCalled = false; 
                }
                else 
                {
                    elevatorButton.GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
                    elevatorCalled = true; 
                }
                elevator.CallElevator();
            }
        }
    }
}
