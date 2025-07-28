using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class capsule_agent : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public float dist_min;
    public float dist_max;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, agent.transform.position);
        if (dist>dist_min && dist < dist_max)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = agent.transform.position;
        }
  
    }
}
