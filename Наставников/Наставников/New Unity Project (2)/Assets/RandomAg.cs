using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomAg : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public float min;
    public float max;
    public float dist;


    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, agent.transform.position);
        if (dist > min && dist < max)
        {
            agent.destination = new Vector3(this.Rand(), 0.635f, this.Rand());
        }
        else
        {
            agent.destination = agent.transform.position;
        }

    }
    public float Rand()
    {
        return Random.Range(min, max);
    }
}
