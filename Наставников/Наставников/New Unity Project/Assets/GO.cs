using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{
    public Transform player;
    public Transform camer;
    public float speed;
    public Rigidbody Rigi;
    public float rotat_spd;
    public float rot;
    public float updown;
    public float max;
    // Start is called before the first frame update
    void Update()
    {
        rot = player.localEulerAngles.y + Input.GetAxis("Mouse X") * rotat_spd;
        updown -= rotat_spd * Input.GetAxis("Mouse Y");
        updown = Mathf.Clamp(updown, -max , max);
        player.localEulerAngles = new Vector3(0, rot, 0);
        camer.localEulerAngles = new Vector3(updown, 0, 0);
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float horisont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horisont,0,vertical);
        move = player.TransformDirection(move) * speed;
        Vector3 labu = Rigi.velocity;

        Rigi.velocity = move * speed;

        if (move != Vector3.zero){
            Quaternion rot = Quaternion.LookRotation(move, Vector3.up);
            player.rotation = Quaternion.RotateTowards(player.rotation,rot,rotat_spd*Time.deltaTime);
        }

    }

}
