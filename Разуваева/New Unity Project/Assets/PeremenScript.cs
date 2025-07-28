using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PeremenScript : MonoBehaviour
{
    public Camera camera; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //если кнопка мыши нажата true
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();//на переменную сохранятеся компонент текущего GameObjecta
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); //Вычесляет луч мышки в области видения камеры
            RaycastHit hit;//переменная типа пересечения луча

            if (Physics.Raycast(ray, out hit))// функция Raycast вычисляет есть ли пересечение лучей. ray получаем из 20 строчки, out hit значение получает из игры
            {
                if (hit.collider != null) //hit.collider это какой либо компонент, сработает если есть пересечение с каким либо коллайдером
                {
                    string message = "Точка на плоскости: " + hit.point;//формируем строку, которая будет в Debug.Log
                    Debug.Log(message);//получаем строчку и выводит его в консоль
                    //navMeshAgent.destination = hit.point;// hit.point точка, куда нужно пойти, navMeshAgent кему надо идти, destination застявляет navMeshAgent идти куда надо

                    
                }
                
            }
        }
    }
}
