using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] 
    private float speed = 5;
    [SerializeField]
    private float gravity = 1.5f;
    private float jumpHeight = 120;
    private float yVelocity;
    private bool canDoubleJump; 

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, y, 0);

        // velocity = direction * speed 
        Vector3 velocity = direction * speed; 

        if(controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(canDoubleJump == true)
                {
                    yVelocity += jumpHeight;
                    canDoubleJump = false;
                }
            }

            yVelocity -= gravity;
            canDoubleJump = true; 
        }

        velocity.y = yVelocity; 
        controller.Move(velocity * Time.deltaTime); 
    }
}
