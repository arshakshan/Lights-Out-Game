using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections;

public class ChestInteraction : MonoBehaviour
{
    public string requiredKeyName;
    public GameObject messagePanel; // Reference to the Panel
    public GameObject noKeyPanel;
    public TextMeshProUGUI messageText; // Reference to the TextMeshPro Text element
    public string message;

    private bool isPlayerInRange = false;
    private bool isOpened = false;
    public GameObject chestOpen; // Reference to the open chest object
    public GameObject chestClose; 

    private void Start()
    {
        messagePanel.SetActive(false); // Initially hide the panel
        chestOpen.SetActive(false);
        chestClose.SetActive(true);

    }

    private void Update()
    {
        if (isPlayerInRange && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.instance.HasKey(requiredKeyName))
            {
                // Debug.Log("Chest opened!");
                isOpened = true;
                chestOpen.SetActive(true);
                chestClose.SetActive(false);
                ShowMessage(message, 3f); // Show message for 3 seconds
                
            }
            else
            {
                Debug.Log("Find the correct key!");
            }
        }
    }

    private void ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messagePanel.SetActive(true);
        StartCoroutine(HidePanelAfterDelay(delay));
    }

    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messagePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player entered the trigger zone!");
            isPlayerInRange = true;
            if (!Inventory.instance.HasKey(requiredKeyName))
            {
                noKeyPanel.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            noKeyPanel.SetActive(false);
        }
    }
}
