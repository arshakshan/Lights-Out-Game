using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    // [SerializeField] private Collider doorCollider; // Reference to the door's physical collider
    [SerializeField] private bool openTrigger = false;

    public GameObject popupMessage; // Reference to the popup UI
    public GameObject popupFinalMessage; // Reference to the popup UI
    public GameObject cubeThree;
    
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            if (InventoryManager.instance.HasItem("Key")) // Assuming you have a method to check if the player has the key
            {
                // SceneManager.LoadScene("Level 2"); // Load the new scene
                if(!openTrigger){
                    myDoor.Play("OPEN_DOOR", 0, 0.0f);
                    openTrigger = true;
                    // gameObject.SetActive(false);
                    // doorCollider.enabled = false; // Disable the physical collider
                    // doorCollider.enabled = false;
                    Destroy(cubeThree);
                }
            }
            else
            {
                StartCoroutine(ShowPopup("You do not have the key")); // Show the popup
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player"))
        {
            if (InventoryManager.instance.HasItem("Key")) // Assuming you have a method to check if the player has the key
            {
                // SceneManager.LoadScene("Level 2"); // Load the new scene
                if(!openTrigger){
                    // myDoor.Play("OPEN_DOOR", 0, 0.0f);
                    openTrigger = true;
                    // gameObject.SetActive(false);
                }
                StartCoroutine(ShowPositivePopup("You do not have the key")); // Show the popup
            }
        }
    }

    IEnumerator ShowPositivePopup(string message)
    {
        popupFinalMessage.SetActive(true); // Show the popup
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        popupFinalMessage.SetActive(false); // Hide the popup
    }

    IEnumerator ShowPopup(string message)
    {
        popupMessage.SetActive(true); // Show the popup
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        popupMessage.SetActive(false); // Hide the popup
    }
    
}
