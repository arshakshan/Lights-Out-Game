using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject difficultyPanel; // Reference to the difficulty selection panel
    public GameObject mainMenuCanvas; // Reference to the main menu panel
    public GameObject mainMenuPanel; // Reference to the main menu panel

    public GameObject continueButton;
    public IntroTextManager introTextManager; // Reference to the IntroTextManager


     void Start()
     {
         mainMenuPanel.SetActive(true);
         introTextManager.introText.SetActive(false);
         
     }

     void Update(){
        // if(GameStateManager.GameIsPlayable){
        //     continueButton.SetActive(true);
        // }

        // Check for the Escape key to toggle the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainMenu();
        }

        // Update the continue button's visibility
        continueButton.SetActive(GameStateManager.GameIsPlayable);
     }

     public void ToggleMainMenu()
    {
        // Toggle the main menu's visibility
        bool isMenuActive = mainMenuPanel.activeSelf;
        mainMenuPanel.SetActive(!isMenuActive);
    }

    
    public void ShowDifficultyMenu()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(true); // Show the difficulty menu
    }

    public void HideDifficultyMenu()
    {
        difficultyPanel.SetActive(false); // Hide the difficulty menu
        
    }

    public void ContinueGame(){
        mainMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        // Load the game scene
        Debug.Log("Starting game");
        GameStateManager.GameIsPlayable = false;
        SceneManager.LoadScene("Level 1"); // Replace with your game scene name
    }


    public void SetDifficulty(string difficulty)
    {
        Debug.Log("Difficulty set to: " + difficulty);
        DifficultyManager.CurrentDifficulty = difficulty;
        // Set the difficulty here
        // Hide the difficulty menu after selection
        GameStateManager.GameIsPlayable = true;
        // SceneManager.Upd("Level 2");
        
        // Update health based on difficulty
        HealthBarController healthBarController = FindObjectOfType<HealthBarController>();
        if (healthBarController != null) {
            healthBarController.InitializeHealthBasedOnDifficulty();
        }

        HideDifficultyMenu();
        Debug.Log("Show Intro Text ");
        // Invoke IntroTextManager to display intro text
        if (introTextManager != null)
        {
            introTextManager.DisplayIntroTextMethod(); // Replace with the actual method name
        }
    }

    public void EndGame()
    {
        // Quit the application
        Debug.Log("End Game called. Quitting application.");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif

    }
}
