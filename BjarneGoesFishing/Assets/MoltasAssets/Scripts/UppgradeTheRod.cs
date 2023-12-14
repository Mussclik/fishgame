using UnityEngine;
using UnityEngine.UI;


public class UppgradeTheRod : MonoBehaviour
{

    public Sprite[] images; // Array av bilder att byta mellan
    public Image displayImage; // Referens till Image-komponenten som visar bilden
    private int currentIndex = 0; // Index för den aktuella bilden

    void Start()
    {
        // Sätt den första bilden när spelet startar
        DisplayCurrentImage();
    }

    void Update()
    {
        // Du kan också byta bild med en knapptryckning, till exempel mellanslagstangenten
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchImage();
        }
    }

    // Funktion för att byta bild när knappen klickas på
    public void OnButtonClick()
    {
        SwitchImage();
    }

    // Funktion för att byta bild
    void SwitchImage()
    {
        // Öka indexet med 1 (om indexet är på den sista bilden, återgå till den första)
        currentIndex = (currentIndex + 1) % images.Length;

        // Visa den aktuella bilden
        DisplayCurrentImage();
    }

    // Funktion för att visa den aktuella bilden i displayImage-komponenten
    void DisplayCurrentImage()
    {
        // Se till att images-arrayen inte är tom
        if (images.Length > 0)
        {
            // Sätt den aktuella bilden
            displayImage.sprite = images[currentIndex];
        }
    }
}
