using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    //BoostSpeed НЕ РАБОТАЕТ

    public Transform ball;
    public Transform cylinder;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") //прикоснулся ли игрок
        {
            //cylinder.SetA;
        }
    }
}
