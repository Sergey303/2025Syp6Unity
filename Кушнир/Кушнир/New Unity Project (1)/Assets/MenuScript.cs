using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour


{
    // Start is called before the first frame update

    public Text text;
    public int counter;
    public Image menu;
    public int save;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void PlusKlik()

    {
        counter += 1;
        text.text = counter.ToString();
    }

    public void MinusKlik()
    {
        counter -= 1;
        text.text = counter.ToString();
    }

    public void Hider()
    {
        menu.gameObject.SetActive(false);
    }

    public void MenuAktive()
    {
        menu.gameObject.SetActive(true);
    }

    public void Save()
    {
        save = counter;
        PlayerPrefs.SetInt("counter", save);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        counter = PlayerPrefs.GetInt("counter");
        text.text = counter.ToString();
    }
}

