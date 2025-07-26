using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardMove : MonoBehaviour
{
    public Transform transformer;
    public float speed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        transformer.position = new Vector3(transformer.position.x + speed, transformer.position.y, transformer.position.z);
    }
}
