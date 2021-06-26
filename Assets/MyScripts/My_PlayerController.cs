using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class My_PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] 
    private float speed = 5;
    [SerializeField]
    private float gravity = 1.5f;
    private float jumpHeight = 60;
    private float yVelocity;
    private bool canDoubleJump;
    [SerializeField]
    private int coinCount;
    [SerializeField]
    private My_UI_Manager uI_Manager;
    [SerializeField]
    private int lives = 3; 

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        uI_Manager = GameObject.Find("Canvas").GetComponent<My_UI_Manager>(); 

        if(uI_Manager == null)
        {
            Debug.LogError("No reference to UI Manager"); 
        }

        uI_Manager.UpdateLivesInfo(lives);
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

    public void AddCoins(int coin)
    {
        coinCount++;
        uI_Manager.UpdateCoinInfo(coinCount); 
    }

    public void TakeDamage()
    {
        lives--;
        uI_Manager.UpdateLivesInfo(lives); 

        if(lives < 1)
        {
            SceneManager.LoadScene(0); 
        }
    }
}