using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform camera; //камера
    public Transform ball; //мяч (мы)
    public float horisont;
    public float verical;
    public float speed;
    public float speedjump;
    public Vector3 moveVector;
    public Transform BoostSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //получаем компонент Rigidbody с нашего объекта
    }

    //буст от цилиндра, не работает
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Cylinder") //прикоснулся ли игрок
    //    {
    //        speed+=4;
    //    }
    //}

    void FixedUpdate()
    {
        //прыжок
        if (Input.GetKey(KeyCode.Space)) //если нажат пробел
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + speedjump, ball.transform.position.z); //мяч поднимается (телепортируется) на speedjump
            //rigidbody.AddForce(Physics.gravity * rigidbody.mass);
        }

        //движение
        moveVector.x = Input.GetAxis("Horizontal");
        rigidbody.MovePosition(rigidbody.position + moveVector * speed); //двигает тело (физикой)
    }
}
