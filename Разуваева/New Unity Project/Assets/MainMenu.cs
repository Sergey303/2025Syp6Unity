using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

{
    public Text text;
    public int count;
    public Image image;
    public GameObject menu;
    public GameObject cat;
    public List<Sprite> cats;
    public int cats_nam;
    public Image cat_image;
    public Transform player;

    public void Loading()
    {
        Debug.Log("loading");
        count = PlayerPrefs.GetInt("count");
        text.text = count.ToString();
    }
    public void LoadingPlayer()
    {
        Debug.Log("loadingplayer");
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        player.position = new Vector3(x, y, z);
    }

    public void Save()
    {
        Debug.Log("save");
        PlayerPrefs.SetInt("count", count);
        PlayerPrefs.GetFloat("x", player.position.x);
        PlayerPrefs.GetFloat("y", player.position.y);
        PlayerPrefs.GetFloat("z", player.position.z);
        PlayerPrefs.Save();
    }
    public void Plus()
    {
        count = count + 1;
        text.text = count.ToString();

    }
    public void Minus()
    {
        count -= 1;
        text.text = count.ToString();
    }
    public void On_off()
    {
        if (image.enabled)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
            
    }
    public void Menu_On()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
        //menu.SetActive(true);
    }
    public void On_off_photo()
    {
        if (image.enabled)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
    }
    public void left()
    {
        cats_nam -= 1;
        if (cats_nam < 0)
        {
            cats_nam = 2;
        }
        cat_image.sprite = cats[cats_nam];
    }
    public void right()
    {
        cats_nam += 1;
        if (cats_nam > 2)
        {
            cats_nam = 0;
        }

        cat_image.sprite = cats[cats_nam];
    }
   public void Cats_On()
    {
        if (cat.activeSelf)
        {
            cat.SetActive(false);
        }
        else
        {
            cat.SetActive(true);
        }
        //menu.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        text.text = "ijijihoii";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
