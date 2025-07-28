using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    public NavMeshAgent man; //наш агент

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //если кнопка мышки нажата и отпущена
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //создаем луч из направления камеры и мышки
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //если есть пересечение, получаем информацию о нем
            {
                Transform objectHit = hit.transform; //находим transform объекта, в который мы попали лучом
                man.destination = hit.point; //идет в точку
            }
        }
    }
}
