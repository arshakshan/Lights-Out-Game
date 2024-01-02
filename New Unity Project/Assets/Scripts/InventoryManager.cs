using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    // public PlayerLocomotion player;

    public InventoryItem[] items; // The player's inventory as an array
    public int maxItems = 4; // Maximum number of items the player can carry

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryManager found!");
            return;
        }
        instance = this;
        items = new InventoryItem[maxItems]; // Initialize the array with the maximum number of items
    }

    // Add an item to the inventory
    public bool AddItem(InventoryItem itemToAdd)
    {
        // Check for unique item
        if (itemToAdd.isUnique && System.Array.Exists(items, item => item != null && item.isUnique && item.itemName == itemToAdd.itemName))
        {
            Debug.Log("You can't carry more than one of this item!");
            return false;
        }
        
        // Find the first empty slot in the inventory
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                Debug.Log($"Item added: {itemToAdd.itemName}"); // Debug statement
                InventoryUIManager.instance.AddItemToInventoryUI(i, itemToAdd.itemIcon); // Update UI
                return true;
            }
        }

        Debug.Log("Not enough room.");
        return false;
    }

    // Use an item from the inventory
    public void UseItem(int slotIndex)
    {
        InventoryItem itemToUse = items[slotIndex];
        // if (itemToUse != null)
        // {
        //     if (itemToUse.itemName == "HealthPack" && player.currentHealth < player.maxHealth)
        //     {
        //         player.HealPlayer(10); // Assuming health pack heals 10 health
        //         items[slotIndex] = null; // Remove item from the slot
        //         InventoryUIManager.instance.RemoveItemFromInventoryUI(slotIndex); // Update UI
        //     }
            
        //     // For other items, add additional conditions and effects here
        //     items[slotIndex] = null;
        //     InventoryUIManager.instance.RemoveItemFromInventoryUI(slotIndex); // Update UI
        // }
    }

    // Remove an item from the inventory without using it
    public void RemoveItem(int slotIndex)
    {
        if (items[slotIndex] != null)
        {
            items[slotIndex] = null; // Remove the item from the slot
            InventoryUIManager.instance.RemoveItemFromInventoryUI(slotIndex); // Update UI
        }
    }

    public bool HasItem(string itemName)
    {
        return items.Any(item => item != null && item.itemName == itemName);
    }

    public void RemoveItemByName(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].itemName == itemName)
            {
                items[i] = null;
                InventoryUIManager.instance.RemoveItemFromInventoryUI(i); // Update UI
                break;
            }
        }
    }

}
