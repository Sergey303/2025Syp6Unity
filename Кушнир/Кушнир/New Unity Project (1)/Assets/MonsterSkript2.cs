using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkript2 : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "player")
        {
            cube1.SetActive(true);
            cube2.SetActive(true);
            cube3.SetActive(true);
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

