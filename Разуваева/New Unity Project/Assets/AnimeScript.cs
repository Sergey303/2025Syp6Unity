using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimeScript : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent Anime;
    public Camera camera;
    public float distant;
    public float distant_Min;
    public float distant_Max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Точка на плоскости: " + hit.point);
                }
            }
        }
        distant = Vector3.Distance(player.transform.position, Anime.transform.position);
        if(distant > distant_Min & distant < distant_Max)
        {
            Anime.destination = player.transform.position;
        }
        else
        {
            Anime.isStopped = true;
            Anime.ResetPath();
        }
    }
}
