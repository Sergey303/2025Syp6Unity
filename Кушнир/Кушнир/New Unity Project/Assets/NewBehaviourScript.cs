using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public float speed;


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.position = new Vector3(player.position.x, player.position.y, player.position.z + speed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            player.position = new Vector3(player.position.x - speed, player.position.y, player.position.z );

        }
        if (Input.GetKey(KeyCode.D))
        {
            player.position = new Vector3(player.position.x + speed, player.position.y, player.position.z);

        }
    }
}
