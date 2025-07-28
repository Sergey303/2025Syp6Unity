using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory; //окно инвентаря

    public void InventoryF()
    {
        if (Input.GetKeyUp(KeyCode.E)) //если кнопка E нажата
        {
            if (inventory.activeSelf) //активен ли объект (инвентарь)
            {
                inventory.SetActive(false); //выключаем окно инвентаря
            }
            else
            {
                inventory.SetActive(true); //включаем окно инвентаря
            }
        }
    }

    void FixedUpdate()
    {
        InventoryF(); //вызываем функцию
    }
}
