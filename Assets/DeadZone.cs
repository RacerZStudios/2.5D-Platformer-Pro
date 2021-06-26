using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject respawnPos; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>(); 
            if(player != null)
            {
                player.TakeDamage(); 
            }

            CharacterController characterController = other.GetComponent<CharacterController>(); 
            if(characterController != null)
            {
                characterController.enabled = false; 
            }
            other.transform.position = respawnPos.transform.position;
            StartCoroutine(CharacterControllerRoutine(characterController));
        }
    }

    IEnumerator CharacterControllerRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true; 
    }
}