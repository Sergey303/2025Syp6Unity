using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour

{
    // Start is called before the first frame update
    public Transform player;
    public float speed;
    public CharacterController controller;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.position = new Vector3(player.position.x, player.position.y, player.position.z - speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.position = new Vector3(player.position.x + speed, player.position.y, player.position.z);

        }

        if (Input.GetKey(KeyCode.D))
        {
            player.position = new Vector3(player.position.x - speed, player.position.y, player.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.position = new Vector3(player.position.x , player.position.y, player.position.z + speed);
        }
    }
}