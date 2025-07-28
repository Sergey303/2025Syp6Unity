using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public GameObject ball;
    public GameObject options;
    public Text text;
    public int count;

    //сохранение
    public void save()
    {
        //сохранение места
        string json = JsonUtility.ToJson(ball.transform.position);
        PlayerPrefs.SetString("position", json); //запоминаем переменную json с ключом "position"

        //сохранение count
        PlayerPrefs.SetInt("count1", count); //запоминаем переменную count с ключом "count1"
        //Debug.Log(json);
    }

    //загружение
    public void load()
    {
        //загружение места
        string json = PlayerPrefs.GetString("position"); //получаем сохраненный json, с помощью ключа
        Vector3 pos = JsonUtility.FromJson<Vector3>(json); //конвертируем в Vector3
        ball.transform.position = pos; //присваеваем мячу место (pos)

        //загружение count
        count = PlayerPrefs.GetInt("count1"); // получаем сохраненный count, с помощью ключа
        text.text = count.ToString(); //присваеваем тексту на экране число, переведенное в строку
        //Log("Load");
    }
    public void plus()
    {
        count++; //увеличиваем count
        text.text = count.ToString(); //присваеваем тексту на экране число, переведенное в строку
    }
    public void minus()
    {
        count--; //уменьшаем count
        text.text = count.ToString(); //присваеваем тексту на экране число, переведенное в строку
    }

    public void reset()
    {
        ball.transform.position = new Vector3(-95, 5, -2); //возращаем мяч в начало
    }
    public void OnOff()
    {
        if (options.activeSelf) //если options активен
        {
            options.SetActive(false); //выключаем
        } else
        {
            options.SetActive(true); //включаем
        }
    }
}
