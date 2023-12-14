using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextForBoat : MonoBehaviour
{
    public Text displayText;  // Connect the Text UI component here
    public string bajamaja;

    private void Start()
    {
        // Hide the text when the game starts
        HideText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if it's the player entering the trigger
        if (other.CompareTag("Player"))
        {
            // Show the text
            ShowText(bajamaja);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if it's the player leaving the trigger
        if (other.CompareTag("Player"))
        {
            // Hide the text
            HideText();
        }
    }

    private void ShowText(string message)
    {
        // Show the text on the UI element
        if (displayText != null)
        {
            displayText.text = message;
            displayText.enabled = true;
        }
    }

    private void HideText()
    {
        // Hide the text on the UI element
        if (displayText != null)
        {
            displayText.enabled = false;
        }
    }
}
