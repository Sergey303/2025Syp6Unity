using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_go_up : MonoBehaviour
{
    public Transform transformwall;
    public float speed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //transformplayer.transform.position = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transformwall.position = new Vector3(3, transformwall.position.y + speed, 15);
    }
}
