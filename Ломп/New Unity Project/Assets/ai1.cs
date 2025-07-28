using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ai1 : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float dis;
    public float dismi;
    public float disma;


    void Update()
    {
        dis = Vector3.Distance(player.transform.position, agent.transform.position);
        if (dis > dismi && dis < disma)
        {
            agent.destination = player.transform.position;

        }
        else
        {
            agent.destination = agent.transform.position;
        }
    }
}
