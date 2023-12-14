using UnityEngine;
using UnityEngine.UI;


public class UppgradeTheRod : MonoBehaviour
{

    public Sprite[] images; // Array av bilder att byta mellan
    public Image displayImage; // Referens till Image-komponenten som visar bilden
    private int currentIndex = 0; // Index f�r den aktuella bilden

    void Start()
    {
        // S�tt den f�rsta bilden n�r spelet startar
        DisplayCurrentImage();
    }

    void Update()
    {
        // Du kan ocks� byta bild med en knapptryckning, till exempel mellanslagstangenten
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchImage();
        }
    }

    // Funktion f�r att byta bild n�r knappen klickas p�
    public void OnButtonClick()
    {
        SwitchImage();
    }

    // Funktion f�r att byta bild
    void SwitchImage()
    {
        // �ka indexet med 1 (om indexet �r p� den sista bilden, �terg� till den f�rsta)
        currentIndex = (currentIndex + 1) % images.Length;

        // Visa den aktuella bilden
        DisplayCurrentImage();
    }

    // Funktion f�r att visa den aktuella bilden i displayImage-komponenten
    void DisplayCurrentImage()
    {
        // Se till att images-arrayen inte �r tom
        if (images.Length > 0)
        {
            // S�tt den aktuella bilden
            displayImage.sprite = images[currentIndex];
        }
    }
}
