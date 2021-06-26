using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Coin_Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            My_PlayerController player = other.GetComponent<My_PlayerController>(); 
            if(player != null)
            {
                player.AddCoins(1); 
            }

            if(player == null)
            {
                Debug.LogError("No reference to other Player tag or component"); 
            }

            Destroy(gameObject); 
        }
    }
}
