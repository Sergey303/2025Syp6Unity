using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent pet;
    public float distanse; // between Player and Pet

    public float MinDistanse = 2;
    public float MaxDistanse;
    // Distance when pet stops following the player

    void Update()
    {
        distanse = Vector3.Distance(player.transform.position, pet.transform.position); // Calculates distance
        if (distanse > MinDistanse && distanse < MaxDistanse) // if pet in range
        {
            pet.isStopped = false;
            pet.destination = player.transform.position; // follows player
        }
        else
        {
            pet.isStopped = true; // stops pet
        }
    }
}
