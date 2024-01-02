using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public InventoryItem inventoryItem;
    //public InventoryItem itemData; // This holds the data for the item

    public InventoryItem GetInventoryItem()
    {
        return inventoryItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    // Attempt to add the item to the player's inventory
        //    bool wasPickedUp = InventoryManager.instance.AddItem(inventoryItem);

        //    // If the item was successfully added to the inventory
        //    if (wasPickedUp)
        //    {
        //        // Optionally play a sound, animation, etc.

        //        // Then, disable or destroy the item object
        //        gameObject.SetActive(false);
        //        // Destroy(gameObject); // Use this if you want to destroy the item instead
        //    }
        //}

        if (other.CompareTag("Player"))
        {
            // Inform the player script that an item has been collided with, but do not add the item here
            Debug.Log("Player has collided with item.");
            // Optionally, you could deactivate or destroy the item here
            //gameObject.SetActive(false); // or Destroy(gameObject);
        }
    }
}
