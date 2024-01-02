using UnityEngine;
using TMPro;
using System.Collections; // Needed for IEnumerator 

public class AnswerButton : MonoBehaviour
{
    public bool isCorrect; // Set this in the inspector for the correct button
    public TextMeshProUGUI resultText; // Reference to a TextMeshPro Text element for showing result
    public HealthBarController health;
    public GameObject finalScreen;
    public GameObject endPuzzle;
    public FinalTextManager finalTextManager; // Reference to the IntroTextManager

    public void OnAnswerSelected()
    {
        Debug.Log("Answer selected: ");
        if (isCorrect)
        {
            // resultText.text = "Correct Answer! ";
            // endPuzzle.SetActive(false);
            StartCoroutine(WaitText());
        }
        else
        {
            resultText.text = "Wrong Answer!";
            health.ModifyHealth(-50);
        }

        // Optionally, add logic here to handle what happens after an answer is selected
    }

    IEnumerator WaitText()
    {
        resultText.text = "Correct Answer!, You Eascaped ! Game Over ";
        yield return new WaitForSeconds(3);
        endPuzzle.SetActive(false);
        // introText.gameObject.SetActive(true); // Show the text
        // // introText.text = "You awaken to a dim, flickering light. The air is cold and stale. As your eyes adjust to the gloom, you find yourself in a room you don't recognize. The walls are lined with obscure symbols, and the only exit, a heavily locked door, seems to mock your confusion. With no memory of how you arrived, you realize the only way out is through unraveling the secrets hidden in the shadows of this forgotten room.";
        
        // introText.gameObject.SetActive(false); // Hide the text after the specified time
        // Debug.Log("Game Ends");
        // finalScreen.SetActive(true);
        if (finalTextManager != null)
        {
            finalTextManager.DisplayIntroTextMethod(); // Replace with the actual method name
        }
        yield return new WaitForSeconds(1);
        // FindObjectOfType<PlayerMovement>().HandleGameOver();
    }
}
