using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FinalTextManager : MonoBehaviour
{
    public GameObject introText; // Assign your UI Text element in the Inspector
    public float displayTime = 12.0f; // Time in seconds for which the text is displayed

    void Start()
    {
        // StartCoroutine(DisplayIntroText());
    }

    public void DisplayIntroTextMethod()
    {
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        introText.gameObject.SetActive(true); // Show the text
        // introText.text = "You awaken to a dim, flickering light. The air is cold and stale. As your eyes adjust to the gloom, you find yourself in a room you don't recognize. The walls are lined with obscure symbols, and the only exit, a heavily locked door, seems to mock your confusion. With no memory of how you arrived, you realize the only way out is through unraveling the secrets hidden in the shadows of this forgotten room.";
        yield return new WaitForSeconds(displayTime);
        // introText.gameObject.SetActive(false); // Hide the text after the specified time
    }

    public void CloseMessage()
    {
        introText.gameObject.SetActive(false); // Hide the text after the specified time
    }
}
