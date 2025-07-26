using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerSpeed;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    [Range (0.2f, 15f)] public float mouseSensitivity = 2f;
    // Improves Unity interface
    public float jumpHeight = 3f;
    private Rigidbody rigidBody; // Rigidbody (physics) component of player
    public Transform Camera; // CAmera
    private float CameraY; // Camera rotation up and down
    public int leftFreeJumps; // how much free jumps left
    public int totalFreeJumps = 2; // How much Free jumps available each time player stands on ground

    public void returner() // returns player to spawn
    {
        transform.position = new Vector3(1, 1, 1);
    }

    // Use this for initialization
    void Start()
    {
        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        CameraY = Camera.eulerAngles.x;
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // gets mouse axis
        float MouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.eulerAngles += new Vector3(0, MouseX, 0); // spins the body

        Camera.eulerAngles += new Vector3(MouseY, 0, 0); // spins the camera
        //if (CameraY != Mathf.Clamp(CameraY, -50, 50))
        
        if (CameraY > 180 && CameraY < 310) 
        {
            Camera.eulerAngles = new Vector3(310, Camera.eulerAngles.y, Camera.eulerAngles.z);  
        }
        else if (CameraY > 50 && CameraY < 180) 
        {
            Camera.eulerAngles = new Vector3(50, Camera.eulerAngles.y, Camera.eulerAngles.z); 
        } // stops camera from overspinning

        


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && leftFreeJumps > 0)
        {
            rigidBody.velocity += transform.up * jumpHeight;// applies force in the up direction
            leftFreeJumps--; // reduces free jumps
        }
        

        //Sprt
        if (Input.GetKey(KeyCode.LeftShift)) // increases speed is LShift is pressed
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }


    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed; // applies force to sides
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed; // applies force to front and back
        } // body movement
    }

    private void OnTriggerEnter() // if feet are on the ground
    {
        leftFreeJumps = totalFreeJumps; // resets free jumps
    }
}