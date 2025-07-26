using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject loading;
    // Loading image
    public GameObject menu;
    public string human;
    public InputField inputField;
    public void QuitGame()
    {
        Application.Quit();
        // Game quitting function
    }

    public GameObject toyota;
    public void ToyotaSpawner()
    {
        toyota.SetActive(!toyota.activeSelf);
    }

    public GameObject footballField;
    public void FootballFieldSpawner()
    {
        footballField.SetActive(!footballField.activeSelf);
    }

    public GameObject su37;
    public void Su37Spawner()
    {
        su37.SetActive(!su37.activeSelf);
    }

    public GameObject pet;
    public void PetSpawner()
    {
        pet.SetActive(!pet.activeSelf);
    }


    public void SetMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    /*
    public void Plus()
    {
        count++;
        text.text = count.ToString();
    }

    public void Minus()
    {
        count--;
        text.text = count.ToString();
    }
    */

    void Start()
    {
        menu.SetActive(false);
        toyota.SetActive(false);
        footballField.SetActive(false);
        su37.SetActive(false);
        pet.SetActive(false);
        loading.SetActive(false);
        // Turning off everything
    }

    public void TurnOnLoading()
    {
        loading.SetActive(true);
        // Shows Loading image
    }

    public void TurnOffLoading()
    {
        loading.SetActive(false);
        // Hides loading image
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetMenu();
        }
        // Press Esc to open/hide Menu
        else if (Input.GetKey(KeyCode.T) && Input.GetKeyDown(KeyCode.O))
        {
            ToyotaSpawner();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.U))
        {
            Su37Spawner();
        }
        else if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.O))
        {
            FootballFieldSpawner();
        }
        else if (Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.E))
        {
            PetSpawner();
        }
        // Binds for GameObject spawners
        else if (loading.activeSelf)
        {
            loading.transform.Rotate(Vector3.back * 270 * Time.deltaTime);
            //Spins loading image
        }
    }
}
