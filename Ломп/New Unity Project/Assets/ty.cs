using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ty : MonoBehaviour
{
    public Transform legs;
    public Rigidbody rig;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.2f;
    public bool isground;
    private bool isJumping;
    void FixedUpdate()
    {
       // isground = Physics.Raycast(legs.transform.position, Vector3.down, groundCheckDistance, groundLayer);
        if (!isground && isJumping && rig.velocity.y <= 0)
        {
            isJumping = false;
        }
    }

    void Update()
    {
        //isground = Physics.Raycast(legs.transform.position, Vector3.down, groundCheckDistance, groundLayer);
        if (Input.GetKey(KeyCode.Space) && isground && !isJumping)
        {
            isJumping = true;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
