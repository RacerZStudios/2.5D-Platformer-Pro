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
    [SerializeField]
    private float jumpHeight = 45;
    [SerializeField]
    private float yVelocity;
    private bool canDoubleJump;
    private bool canWallJump; 
    [SerializeField]
    private int coinCount;
    [SerializeField]
    private My_UI_Manager uI_Manager;
    [SerializeField]
    private int lives = 3;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 wallSurfaceNormal;
    [SerializeField]
    private float pushForce = 15; 

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

        if(controller.isGrounded == true)
        {
            canWallJump = true; 
            direction = new Vector3(x, 0, 0);
            // velocity = direction * speed 
            velocity = direction * speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                canDoubleJump = true; 
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canWallJump == false)
            {
                if(canDoubleJump == true)
                {
                    yVelocity += jumpHeight;
                    canDoubleJump = false;
                }
            }

            if(Input.GetKeyDown(KeyCode.Space) && canWallJump == true)
            {
                yVelocity = jumpHeight; 
                // velocity = surface normal of the wall 
                velocity = wallSurfaceNormal * speed; 
            }
            yVelocity -= gravity;
        }

        velocity.y = yVelocity; 
        controller.Move(velocity * Time.deltaTime); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) // detect hit info from ray point and normal 
    {
        // if not grounded && touching wall
        if(controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.cyan);
            wallSurfaceNormal = hit.normal; 
            canWallJump = true; 
        }

        // check for moving box 
        if(controller.isGrounded == true && hit.transform.tag == "MoveBox")
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            rb.isKinematic = false; 
            if(rb == null || rb.isKinematic)
            {
                return; 
            }

            if(hit.moveDirection.y < -0.2f)
            {
                return; 
            }

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0); 

            rb.velocity = pushDir * pushForce;  
        }
    }

    public void AddCoins(int coin)
    {
        coinCount++;
        uI_Manager.UpdateCoinInfo(coinCount); 
    }

    public int CoinCount() // call coin count to get value 
    {
        return coinCount; 
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