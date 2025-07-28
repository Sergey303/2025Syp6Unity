using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroyWood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            Destroy(other.gameObject);
            Instantiate(destroyWood,other.transform.position, other.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
