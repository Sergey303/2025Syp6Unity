using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "player")
        {
            cube1.SetActive(true);
            cube2.SetActive(true);
            cube3.SetActive(true);
            cube4.SetActive(true);
            cube5.SetActive(true);
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

