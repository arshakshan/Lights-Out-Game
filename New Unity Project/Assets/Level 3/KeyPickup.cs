using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inventory.instance.AddKey(gameObject.name);
            gameObject.SetActive(false); // or Destroy(gameObject);
        }
    }
}