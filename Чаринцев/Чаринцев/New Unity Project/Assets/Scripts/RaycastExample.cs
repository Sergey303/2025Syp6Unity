using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //создаем луч из направления камеры и мышки
        RaycastHit hit; //объект
        if (Physics.Raycast(ray, out hit)) //если есть пересечение, получаем информацию о нем
        {
            Transform objectHit = hit.transform; //находим transform объекта, в который мы попали лучом
        }
    }
}
