using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager instance;

    public GameObject inventoryUI; // The entire UI
    public Button[] itemButtons; // Buttons for the items
    public Sprite defaultIcon; // The default icon for an empty slot
    public Button inventoryToggleButton; // Button to toggle inventory
    public Button closeButton; // Button to close the inventory


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryUIManager found!");
            return;
        }
        instance = this;
        // Optionally, you could hide the inventory and show the toggle button on start
        inventoryUI.SetActive(false);
        inventoryToggleButton.gameObject.SetActive(true);
    }

    public void ToggleInventory()
    {
        // This method toggles the visibility of the inventory
        bool isInventoryActive = inventoryUI.activeSelf;
        inventoryUI.SetActive(!isInventoryActive);
        inventoryToggleButton.gameObject.SetActive(isInventoryActive);
    }

    public void ShowInventory()
    {
        // This method shows the inventory and hides the toggle button
        inventoryUI.SetActive(true);
        inventoryToggleButton.gameObject.SetActive(false);
    }

    public void HideInventory()
    {
        // This method hides the inventory and shows the toggle button
        inventoryUI.SetActive(false);
        inventoryToggleButton.gameObject.SetActive(true);
    }

    // Modified method using slotIndex to add an item
    public void AddItemToInventoryUI(int slotIndex, Sprite itemIcon)
    {
        if (slotIndex < 0 || slotIndex >= itemButtons.Length) return;

        itemButtons[slotIndex].image.sprite = itemIcon;
        itemButtons[slotIndex].interactable = true; // Enable button if an item is present
    }


    // Modified method using slotIndex to remove an item
    public void RemoveItemFromInventoryUI(int slotIndex)
    {
        //if (slotIndex < 0 || slotIndex >= itemButtons.Length) return;

        //itemButtons[slotIndex].GetComponent<Image>().sprite = defaultIcon;
        //itemButtons[slotIndex].gameObject.SetActive(false);
        if (slotIndex < 0 || slotIndex >= itemButtons.Length) return;

        itemButtons[slotIndex].image.sprite = defaultIcon;
        itemButtons[slotIndex].interactable = false; // Disable button if no item is present
        itemButtons[slotIndex].gameObject.SetActive(true); // Make sure the button is still active
    }

    // Existing method for handling button clicks
    public void OnItemButtonClicked(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= InventoryManager.instance.items.Length) return;

        InventoryItem clickedItem = InventoryManager.instance.items[slotIndex];
        if (clickedItem != null && clickedItem.itemName!="BookOfWisdom")
        {
            InventoryManager.instance.UseItem(slotIndex); // Pass the slotIndex instead of the item
        }
    }
}
