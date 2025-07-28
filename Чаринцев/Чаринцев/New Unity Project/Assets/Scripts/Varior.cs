using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Varior : MonoBehaviour
{
    public GameObject player; //наш игрок
    public NavMeshAgent agent; //чел, который бежит на игрока (на нас)
    public float distance; //дистанция
    public float distance_min; //миниальная дистанция виденья игрока
    public float distance_max; //максимальная дистанция виденья игрока
 
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position); //находим рассояние между двумя точками
        if (distance > distance_min && distance < distance_max) //проверяем, дистанцию между игроком и агентом больше минимального и меньше максимального
        {
            agent.destination = player.transform.position; //агент идет на игрока (на нас)
        } else
        {
            agent.destination = transform.position; //идет туда, где находиться (стоит на месте)
        }
    }
}
