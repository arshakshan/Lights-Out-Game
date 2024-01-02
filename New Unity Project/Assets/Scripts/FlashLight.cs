using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashlight_ground, flashlight_player;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
          
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flashlight_ground.SetActive(false);

            flashlight_player.SetActive(true);
        }
    }
}