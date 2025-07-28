using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public Transform man; //игрок (вы)

    //взрыв мины
    private void OnCollisionEnter(Collision collision) //колизии объектов соприкоснулись
    {
        if (collision.gameObject.tag == "Player") //прикоснулся ли игрок
        {
            man.transform.position = new Vector3(man.transform.position.x, man.transform.position.y + 4, man.transform.position.z); //игрок подлетает вверх на 4 (телепортируется)
        }
    }
}
