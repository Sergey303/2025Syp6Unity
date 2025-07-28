using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Скрипт для работы врагов
/// </summary>
public class VragRunScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public int timer;
    public bool spawnOn;
    /// <summary>
    /// Метод вызывается при запуске игры
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Метод вызывается постоянно
    /// </summary>
    void Update()
    {

        // запоминаем позицию игрока
        Vector3 v3 = player.position;
        // запоминаем позицию капсулы
        Vector3 v2 = this.gameObject.transform.position;
        // измеряем дистанцию между обьектами 
        float dist = Vector3.Distance(v2, v3);
        // проверяем, больше или меньше дистанция между обьектами, чем максимальная и минимальная дистанция
        if (dist > maxDistans || dist < minDistans)
        {
            // остаёмся на месте
            agent.destination = transform.position;

        }
        else
        {
            // двигаемся к игроку
            agent.destination = player.position;

        }

        if(timer > 0)
        {
            timer -= 1;

        }
        else
        {
            spawnOn = true;
        }

        if(dist <= minDistans && spawnOn)
        {
            //Instantiate(this.gameObject, this.gameObject.transform.position, Quaternion.identity);
            spawnOn = false;
            timer = 300;
        }

    }
    public Transform player;
    public float minDistans;
    public float maxDistans;

    
}
