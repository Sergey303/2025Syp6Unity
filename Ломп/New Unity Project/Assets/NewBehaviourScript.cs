using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    public Transform player;
    public Transform cam; 
    public float speed;
    public Rigidbody rig;
    public float rot_speed;
    public float rot;
    public float upDown;
    public float max;


    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(hor, 0, ver); 
        mov = player.TransformDirection(mov) * speed;
        rig.velocity = speed * mov;
    }


    void Update()
    {
        rot = player.localEulerAngles.y + Input.GetAxis("Mouse X") * rot_speed;    
        upDown -= rot_speed * Input.GetAxis("Mouse Y");
        upDown = Mathf.Clamp(upDown,-max, max);
        player.localEulerAngles = new Vector3(0, rot, 0);
        cam.localEulerAngles = new Vector3(upDown, 0, 0);

    }
}
