using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public HealthBarController health;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;

    public GameObject popupMessage; // Reference to the popup UI
    public GameObject popupGameMessage; // Reference to the popup UI
    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        popupMessage.SetActive(false); // Ensure the popup is hidden initially
        popupGameMessage.SetActive(false); // Ensure the popup is hidden initially
        playerCamera.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!GameStateManager.GameIsPlayable)
        {
            return; // Skip input processing if the game is not playable
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Key contact detected.");

            ItemScript itemScript = other.GetComponent<ItemScript>();

            if (itemScript != null)
            {
                Debug.Log("ItemScript component found");
                InventoryItem item = itemScript.GetInventoryItem();
                if (item != null && InventoryManager.instance.AddItem(item))
                {
                    Debug.Log("Key added to inventory, destroying object.");

                    Destroy(other.gameObject); // Only destroy the item if it was successfully added to the inventory

                }
                else
                {
                    Debug.Log("Failed to add health pack to inventory.");
                }
            }
            else
            {
                Debug.Log("ItemScript component not found on the object.");
            }
        }
        else if (other.CompareTag("Door"))
        {
            if (InventoryManager.instance.HasItem("Key")) // Assuming you have a method to check if the player has the key
            {
                SceneManager.LoadScene("Level 2"); // Load the new scene
            }
            else
            {
                StartCoroutine(ShowPopup("You do not have the key")); // Show the popup
            }
        }
        else if (other.CompareTag("Crawler"))
        {
            Debug.Log("Health Controller: " + health.currentHealth);
            // health.currentHealth -= 5; // Deduct health using the method in HealthBarController
            health.ModifyHealth(-5); // Add health
            // health.UpdateHealthBar();
            Debug.Log("Health Controller New: " + health.currentHealth);
        }
        else if (other.CompareTag("Health"))
        {
            if(health.currentHealth + 5 <= health.maxHealth){
                Debug.Log("Health Controller: " + health.currentHealth);
            
                // health.currentHealth += 5; // Deduct health using the method in HealthBarController
                health.ModifyHealth(5); // Add health
                // health.UpdateHealthBar();
                Debug.Log("Health Controller New: " + health.currentHealth);
                Destroy(other.gameObject);
            }
           
        }else if (other.CompareTag("HealthGreen"))
        {
            
            if(health.currentHealth + 10 <= health.maxHealth){
                Debug.Log("Health Controller: " + health.currentHealth);
                // health.currentHealth += 10; // Deduct health using the method in HealthBarController
                health.ModifyHealth(10); // Add health
                // health.UpdateHealthBar();
                Debug.Log("Health Controller New: " + health.currentHealth);
                Destroy(other.gameObject);
            }
            
        }
    }

    IEnumerator ShowPopup(string message)
    {
        popupMessage.SetActive(true); // Show the popup
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        popupMessage.SetActive(false); // Hide the popup
    }

    IEnumerator ShowGameOverPopup()
    {
        popupGameMessage.SetActive(true); // Show the popup
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        popupGameMessage.SetActive(false); // Hide the popup
        // GameStateManager.GameIsPlayable = false;
        FindObjectOfType<MainMenu>().EndGame();
        // ResetGame();
        // SceneManager.LoadScene("Level 1"); // Replace with your game scene name
        
    }

    public void HandleGameOver()
    {
        StartCoroutine(ShowGameOverPopup());
        GameStateManager.GameIsPlayable = false;
        // Optionally, disable other player controls here
    }

    void ResetGame()
    {
        GameStateManager.GameIsPlayable = true;
        HealthData.currentHealth = health.maxHealth; // Reset health
        // Reset other necessary states, if any
    }

}
