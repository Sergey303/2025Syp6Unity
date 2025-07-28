using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActivate1 : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject monster;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "player")
        {
            monster.SetActive(true);
            Debug.Log("Aktivated");
            Debug.Log("Aktivated");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
