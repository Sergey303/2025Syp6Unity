using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cortinki : MonoBehaviour
{
    public int inf;
    public TextMesh t1;
    public TextMesh t2;
    public Texture2D n1;
    public Texture2D n2;
    public Texture2D n3;
    public List<Texture2D> rtty = new List<Texture2D>();
    public List<string> rtty1 = new List<string>();
    public List<string> rtty2 = new List<string>();
    public SpriteRenderer img;
    public string st1;
    public string st2;
    public string st3;
    public string st4;
    public Texture2D texture;
    public mymenu ui;


    void Start()
    {
        rtty.Add(n1);
        rtty.Add(n2);
        rtty.Add(n3);
        rtty1.Add("tralolelo tralala");
        rtty1.Add("chpioniro golubiro");
        rtty1.Add("br br patapim"); 
        rtty2.Add("porkodila porkola");
        rtty2.Add("chpioniro golubiro");
        rtty2.Add("br br patapim");
    }

    // Update is called once per frame
    public void START()
    {
        
        if (!string.IsNullOrEmpty(st4) && ui.r == true)
        {
            texture = Resources.Load<Texture2D>(st4);
            rtty.Add(texture);
            ui.num.Add(st1);
            rtty1.Add(st2);
            rtty2.Add(st3);
            st4 = null;
            st3 = null;
            st2 = null;
            st1 = null;
            ui.r = false;

        }
        img.sprite = Sprite.Create(rtty[inf], new Rect(0f, 0f, rtty[inf].width, rtty[inf].height), new Vector2(0.5f, 0.5f), 100f);
        t1.text = rtty1[inf];
        t2.text = rtty2[inf];
        ui.d = false;
        
    }
    public void Update()
    {
        if (ui.d == true || ui.r == true)
        {
            START();
        }
    }
}
