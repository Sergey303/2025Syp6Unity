using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    public Animator animDoorOP;
    public Animator animDoorOP2;
    public bool anim;
    public GameObject u;




    private void Start()
    {

        animDoorOP.StopPlayback();
        animDoorOP2.StopPlayback();
    }

    public void Teleport()
    {

        if (anim == true)
        {
            animDoorOP.StopPlayback();
            animDoorOP2.StopPlayback();
        }
        else
        {
            animDoorOP.Play("Open1");
            animDoorOP2.Play("Open2");
        }
    }
    public void pasha()
    {
        Move BMW = u.GetComponent<Move>();
        BMW.enabled = false;
        u.transform.position = new Vector3(1.5f, 3, -2.8f);
        BMW.enabled = true;
    }
}