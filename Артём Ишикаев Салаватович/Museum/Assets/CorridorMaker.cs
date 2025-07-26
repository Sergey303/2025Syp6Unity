using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorMaker : MonoBehaviour
{

    public GameObject start;
    public GameObject Section;
    public int picNum;


    // Start is called before the first frame update
    void Start()
    {
        int SecNum = (int)(picNum / 2 + 0.5);
        int i = 0;
        for (; i < SecNum; i++)
        {
            GameObject copy = Instantiate(Section);
            copy.transform.position = new Vector3(0, 0, i * 10 + 5);
        }
        GameObject end = Instantiate(start);
        end.transform.position = new Vector3(0, 0, i * 10 + 5);
        end.transform.rotation = new Quaternion(0, 180, 0, 0);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
