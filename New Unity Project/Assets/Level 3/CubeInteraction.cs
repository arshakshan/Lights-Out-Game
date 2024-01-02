using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public GameObject quizPanel; // Reference to the quiz panel

    private void Start()
    {
        quizPanel.SetActive(false); // Initially hide the panel
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.SetActive(true); // Show the panel when the player is close
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.SetActive(false); // Hide the panel when the player leaves
        }
    }

    
}
