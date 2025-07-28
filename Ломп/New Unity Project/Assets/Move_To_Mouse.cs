using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To_Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    Camera mainCamera;
    public GameObject Obj;
    public float distance = 10f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Camera is not assigned!");
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

        if (Obj != null)
        {
            Obj.transform.position = worldPosition;
        }
    }
}
