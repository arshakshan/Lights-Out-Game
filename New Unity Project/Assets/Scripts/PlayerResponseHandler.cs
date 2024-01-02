using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class PlayerResponseHandler : MonoBehaviour
{
    public TMP_InputField playerInputField; // Drag your Input Field here in the Inspector
    private string playerResponse = "";
    public GameObject inputUI; // Reference to the GameObject that contains the input UI elements
    private bool hasSubmitted = false;

    // Call this method when the player clicks the submit button
    public void OnSubmitResponse()
    {
        playerResponse = playerInputField.text;
        // Optionally, you can hide the input UI here
        hasSubmitted = true;
        HideInputUI();
    }

    // Method to fetch the player's response
    public string GetPlayerResponse()
    {
        return playerResponse;
    }

    // Call this method to hide the input UI
    public void HideInputUI()
    {
        inputUI.SetActive(false);
    }

    // Method to check if a response has been submitted
    public bool HasSubmitted()
    {
        return hasSubmitted;
    }

    // Optionally, create a method to show the UI
    public void ShowInputUI()
    {
        inputUI.SetActive(true);
    }

    public void ResetResponse()
    {
        playerResponse = "";
        hasSubmitted = false;
    }
}
