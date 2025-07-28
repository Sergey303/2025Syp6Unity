using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class main_menu : MonoBehaviour
{
    public Text text;
    public int count;
    public Image Wk;
    public GameObject opt;
    public GameObject sirkle;
    public GameObject sircpref;
    public GameObject sharick;
    public GameObject u;
    public bool animB;
    public GameObject BBQ;
    public GameObject Lisa;
    public AudioSource auid;
    public GameObject Ag2;
    public GameObject Ag1;




    // Start is called before the first frame update

    public void plus()
    {
        count++;
        text.text = count.ToString();
    }
    public void minus()
    {
        count--;
        text.text = count.ToString();
    }
    public void Wk_plus()
    {

        if (Wk.enabled == true)
        {
            Wk.enabled = false;
        }
        else
        {
            Wk.enabled = true;
        }
    }
    public void optimus()
    {
        if (opt.activeSelf)
        {
            opt.SetActive(false) ;
        }
        else
        {
            opt.SetActive(true);
        }
    }
    public void moo()
    {
        sharick.gameObject.SetActive(false);
        Wk.enabled = true;
        count = 0;
        text.text = count.ToString();
        text.text = "жми уже куда-нибудь";
        Move BMW = BBQ.GetComponent<Move>();
            BMW.enabled = false;
            u.transform.position = new Vector3(0, 0, 0);
            BMW.enabled = true;
        Lisa.transform.position = new Vector3(0, 0, 0);
        Ag1.transform.position = new Vector3(16.26f, -1.20f, -37.77f);
        Ag2.transform.position = new Vector3(11, -1.25f, -18.25f);
        auid.Stop();
    }
    public void Teleport()
    {
        
        if (animB == true)
        {
             animB = false;
            sharick.gameObject.SetActive(false);
        }
        else
        {
            animB = true;
            
            sharick = Instantiate(sircpref, new Vector3(0, 0, 0), Quaternion.identity);
            sharick.gameObject.SetActive(true);
            auid.Play();

        }
    }
    public void Start()
    {
        auid.Stop();
    }

}
