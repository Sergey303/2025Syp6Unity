using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System;

[Serializable]
public class Image_class
{
    public int ID;
    public List<Sprite> cats;
    public List<Texture2D> Images;
    public List<string> uris;
}


public class Jam : MonoBehaviour
{
    //public CharacterController controller;
    public PhotoURL PhotoURL;
    public Camera camm;    
    public Transform cam;
    public Rigidbody Rig;
    public Transform player;
    public float max = 50;
    public float speed = 1;
    public float pot_speed = 1;
    public float up_down;
    public float hor;
    public float ver;
    public bool move;

    public GameObject target;
    public List<SpriteRenderer> images;
    public List<List<Sprite>> cats;
    public List<int> cats_nambers;
    public int cats_nam;
    public int kartina_id;

    public NavMeshAgent agent;
    public List<Image_class> Img_class;

    public float horizontalSpeed = 2.0f;
    public bool UnLockScreen = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Strelka")
        {
            //target = other.gameObject;
        }
    }
    private void FixedUpdate()
    {

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
            move = true;
        }
        else
        {
            move = false;
        }
        if (move)
        {

            Vector3 move = new Vector3(hor, 0, ver);
            transform.Translate(move * speed);
        }
        float v = horizontalSpeed * Input.GetAxis("Mouse X");
        float h = horizontalSpeed * Input.GetAxis("Mouse Y");
        gameObject.transform.eulerAngles += new Vector3(0, v, 0);
        cam.transform.eulerAngles += new Vector3(-h, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            Ray ray = camm.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Strelka")
                {
                    target = hitInfo.collider.gameObject;
                    kartina_id = target.GetComponent<StrelkaID>().ID;
                }
                else
                {
                    target = null;
                }
            }

            if (target != null)
            {
                if(cats_nambers == null)
                {
                       ;
                }

                if (target.name == "left")
                {
                    cats_nambers[kartina_id] -= 1;
                    if (cats_nambers[kartina_id] < 0)
                    {
                        cats_nambers[kartina_id] = Img_class[kartina_id].uris.Count;
                    }
                    //images[kartina_id].sprite = cats[cats_nambers[kartina_id]];

                    PhotoURL.StartLoadTexture(kartina_id, cats_nambers[kartina_id]);

                    if (cats_nambers[kartina_id] == null || Img_class[kartina_id]?.cats == null || Img_class == null)
                    {
                        return;
                    }
                }
                if (target.name == "right")
                {
                    cats_nambers[kartina_id] += 1;
                    if (cats_nambers[kartina_id] > Img_class[kartina_id].uris.Count)
                    {
                        cats_nambers[kartina_id] = 0;
                    }
                    PhotoURL.StartLoadTexture(kartina_id, cats_nambers[kartina_id]);

                    if (cats_nambers[kartina_id] == null || Img_class[kartina_id]?.cats == null || Img_class == null)
                    {
                        return;
                    }
                }
            }
        }
    }
}
