using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 100f;
    public Transform playerCamera; // Assign the camera in the Inspector
    public CharacterController controller;
    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;
    public bool jet;
    public GameObject sound;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!jet)
        {
            isGrounded = controller.isGrounded;
        }
        else
        {
            isGrounded = true;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        AudioSource audioSource = sound.GetComponent<AudioSource>();
        if (x != 0 || z != 0)
        {
            if(audioSource.isPlaying != true)
            {
                audioSource.Play();
            }
        }
        else
        {

           audioSource.Stop();
        }
        Debug.Log(x);
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}