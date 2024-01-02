using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCScriptConversation1 : MonoBehaviour
{

    public GameObject dialoguePanel; // Reference to the dialogue panel UI
    public TextMeshProUGUI dialogueText; // Reference to the text component for dialogue
    public float typingSpeed = 0.05f; // Speed of typing effect
    private Coroutine messageTypingCoroutine = null;


    private void Start()
    {
        dialoguePanel.SetActive(false); // Make sure the dialogue panel is inactive at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))            
            StartBookConversation();
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (messageTypingCoroutine != null)
            {
                StopCoroutine(messageTypingCoroutine);
                messageTypingCoroutine = null;
            }
            HideMessage();
        }

    }

    // void StartNoBookConversation()
    // {

    //     DialogueEntry[] conversation = new DialogueEntry[]
    //     {
    //         new DialogueEntry { speakerName = "Female Orc", message = "Hello there! Have you found Key?" },
    //         new DialogueEntry { speakerName = "Player", message = "No, I'm still searching for it." },
    //         new DialogueEntry { speakerName = "Female Orc", message = "It's vital to our village. Please find it and bring it back." }
    //     };
    //     StartCoroutine(TypeConversation(conversation));

    // }

    void StartBookConversation()
    {

        DialogueEntry[] conversation = new DialogueEntry[]
    {
        new DialogueEntry { speakerName = "Female Orc", message = "Wanna Escape? EEEEEEEEEE!!!!! " },
        new DialogueEntry { speakerName = "Female Orc", message = "Think Out of the 'BOX'" },
    };
        StartCoroutine(TypeConversation(conversation));
    }

    IEnumerator TypeConversation(DialogueEntry[] conversation)
    {
        dialoguePanel.SetActive(true); // Show the dialogue panel

        foreach (DialogueEntry entry in conversation)
        {
            string formattedMessage = $"{entry.speakerName}: {entry.message}";

            if (messageTypingCoroutine != null)
            {
                StopCoroutine(messageTypingCoroutine);
            }

            messageTypingCoroutine = StartCoroutine(TypeMessage(formattedMessage));
            yield return messageTypingCoroutine; // Wait until the current message is fully typed

            // Check if the player confirms they have the book and remove it
            // if (hasBook && entry.message.Contains("Certainly, here you go."))
            // {
            //     inventoryManager.RemoveItemByName("BookOfWisdom");
            // }
            

            yield return new WaitForSeconds(1); // Wait a second after typing before continuing
        }

        // if (hasBook)
        // {
        //     if (messageTypingCoroutine != null)
        //     {
        //         StopCoroutine(messageTypingCoroutine);
        //     }

        //     messageTypingCoroutine = StartCoroutine(TypeMessage("Thank you! Our village is in your debt."));
        //     yield return messageTypingCoroutine; // Wait until the message is fully typed
        // }
        // dialoguePanel.SetActive(false);
        // inputPanel.SetActive(true); // Make sure the dialogue panel is inactive at the start

        // // Wait for the player to submit their response
        // yield return new WaitUntil(() => playerResponseHandler.HasSubmitted());
        // dialoguePanel.SetActive(true);

        // string playerGradeResponse = playerResponseHandler.GetPlayerResponse();
        
        // if (playerGradeResponse.Equals("A+"))
        // {
        //     // Code to advance the player to the next level
        //     StartCoroutine(TypeMessage("A+? Flattery will get you everywhere! "));
        //     yield return new WaitForSeconds(2); // Wait for the player to read the message
        //     StartCoroutine(TypeMessage("And hey, remind me to never get on your bad side in a grading curve!"));
        //     yield return new WaitForSeconds(5); // Wait for the player to read the message
        //     // StartCoroutine(TypeMessage(""));
        //     // yield return new WaitForSeconds(2); // Wait for the player to read the message
        //     SceneManager.LoadScene("Level 3"); // Replace with your game scene name
        // }
        // else
        // {
        //     // Code to deduct health
        //     FindObjectOfType<HealthBarController>().ModifyHealth(-20);
        //     StartCoroutine(TypeMessage("This is not just a game, 6 lives depend on this!"));
        //     yield return new WaitForSeconds(5); // Wait for the player to read the message
        //     // SceneManager.LoadScene("Level 3"); // Replace with your game scene name
        // }

        // yield return new WaitForSeconds(2); // Give the player some time to read the last message
        HideMessage();
    }


    IEnumerator TypeMessage(string message)
    {
        if (messageTypingCoroutine != null)
        {
            StopCoroutine(messageTypingCoroutine);
        }

        dialogueText.text = ""; // Clear the text

        foreach (char letter in message.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        messageTypingCoroutine = null; // Reset the reference when done
    }

    void HideMessage()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
    }
}
