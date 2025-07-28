using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kas : MonoBehaviour
{
    public Text kills;

    public int mobs;
    public GameObject obg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(obg);
            if (obg == null) return;
            mobs += 1;
            kills.text = mobs.ToString();
            if(mobs >= 100)
            {
                mobs = 0;
                kills.text = "You win";
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            obg = other.gameObject;
        }
        


    }
}
