using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mymenu : MonoBehaviour
{
    public GameObject opt;
    public GameObject opt1;
    public bool jet;
    public Color color1 = Color.red;
    public Color color2 = Color.green;
    public string colorPropertyName = "_Color";
    public Image img1;
    public Movement mov_scr;
    public cortinki ui;
    public bool ch = true;
    public int ind = 0;
    public Text ry;
    public Text ry1;
    public string txt;
    public List<string> num = new List<string>();
    public InputField in1;
    public InputField in2;
    public InputField in3;
    public InputField in4;
    public bool r;
    public bool d;
    void Start()
    {
        num.Add("1");
        num.Add("2");
        num.Add("3");
        txt = ry.text;
        r = false;
        d = false;
    }
    public void Create()
    {
        opt.SetActive(false);
        d = true;
        ui.inf = ind;


    }

    public void Vibor()
    {
        if (ry1.text == num[num.Count - 1])
        {
            txt = num[0];
            ind = 0;
        }
        else
        {
            txt = num[ind +1];
            ind++;
        }
        ry1.text = txt;
    }
    public void On_opts()
    {
        if (!opt.activeSelf)
        {
            opt.SetActive(true);
        }
        else
        {
            opt.SetActive(false);
        }

    }
    public void jetpack()
    {
        if (jet == false)
        {
            img1.color = color2;
            jet = true;
            mov_scr.jet = jet;
        }
        else
        {
            img1.color = color1;
            jet = false;
            mov_scr.jet = jet;

        }
    }
    public void Add()
    {
        opt1.SetActive(true);
        in1.text = null;
        in2.text = null;
        in3.text = null;
        in4.text = null;

    }
    public void Ready()
    {
        opt1.SetActive(false);
        ui.st1 = in1.text;
        ui.st2 = in2.text;
        ui.st3 = in3.text;
        ui.st4 = in4.text;
        r = true;
        in1.text = null;
        in2.text = null;
        in3.text = null;
        in4.text = null;


    }
}
