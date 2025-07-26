using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRotation : MonoBehaviour
{
    public Transform transformer;
    public float speed = 270f; 

    // Update is called once per frame
    void Update()
    {
        transformer.Rotate(transform.up * speed * Time.deltaTime); // rotates the cat
    }
}
