using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lis : MonoBehaviour
{
    public Transform lis;
    public float speed;
    public int pointnum;

    public List<Vector3> points;

    void Update()
    {
        //lis  (points[1] * Speed * Time.fixedDeltaTime);

        lis.position = Vector3.MoveTowards(lis.position, points[pointnum],speed);
        if (lis.position == points[pointnum]) pointnum += 1;
        if (pointnum > 3) pointnum = 0;


    }
    public void MovementLogic()
    {

    }
}
