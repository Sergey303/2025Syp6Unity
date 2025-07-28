using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scare : MonoBehaviour
{
    public GameObject body; //тело, которое будет появляться

    private void OnCollisionEnter(Collision collision) //появление человека(тела)
    {
        if (collision.gameObject.tag == "Player") //прикоснулся ли игрок
        {
            body.SetActive(true); //тело появляется
        }
    }
}
