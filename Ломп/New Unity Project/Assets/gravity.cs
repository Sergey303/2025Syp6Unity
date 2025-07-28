using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public Transform pickPos;
    public bool holding;
    public float dis = 5f;
    public GameObject itm;


    // Update is called once per frame
    void Update()
    {
        hold();


    }
    void Throw(Rigidbody rb)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && holding)
        {
            holding = false;
            rb.AddForce(Camera.main.transform.forward * 50, ForceMode.Impulse);
        }
    }
    void hold()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit ,dis))
            {
                if (hit.transform.gameObject.CompareTag("Garvity"))
                {
                    itm = hit.transform.gameObject;
                    holding = !holding;
                }
            }
        }
        if (itm == null)
        {
            return;
        }
        Rigidbody rb = itm.GetComponent<Rigidbody>();
        if (holding)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            itm.transform.position = pickPos.position;
            itm.transform.parent = pickPos;
            Throw(rb);
;        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            itm.transform.parent = null;
        }
    }
    
}
