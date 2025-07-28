using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GogoGO : MonoBehaviour
{
    public GameObject playeru;
    public UnityEngine.AI.NavMeshAgent agenta;
    public float mind;
    public float maxd;
    public float dista;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dista = Vector3.Distance(agenta.transform.position,playeru.transform.position);
        if (dista > mind && dista < maxd)
        {
            agenta.destination = playeru.transform.position ;
        }
        else
        {
            agenta.destination = agenta.transform.position;
        }

    }
}
