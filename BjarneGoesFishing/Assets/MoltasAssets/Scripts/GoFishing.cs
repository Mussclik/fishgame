using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFishing : MonoBehaviour
{
    public Vector3 targetPosition; // Ange målkoordinaterna i Unity-redigeraren
    public string triggerTag = "Boat"; // Ange triggertaggen i Unity-redigeraren

    private bool isInBoat = false;
    private Rigidbody2D playerRigidbody; // Antag att spelaren har en Rigidbody2D-komponent

    public float timer;
    float timercount = 3f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        timercount = timer;
    }

    void Update()
    {
        if (ÄrInutiTrigger())
        {
            if (Input.GetKeyDown(KeyCode.E) || (Input.GetKey(KeyCode.Joystick1Button3)))
            {
                if (!isInBoat)
                {
                    timer -= Time.deltaTime;

                    if (timer <= 0)
                    {
                        Debug.Log("hej");
                        SceneManager.LoadScene("FishingScene");
                    }
                    FörflyttaObjekt();
                    isInBoat = true;
                }
                else
                {
                    LämnaBåten();
                }
            }
        }
    }

    void FörflyttaObjekt()
    {
        transform.position = targetPosition;
        // Inaktivera rörelsekomponenten när spelaren är i båten
        playerRigidbody.velocity = Vector2.zero;
    }

    void LämnaBåten()
    {
        // Implementera logik för att lämna båten
        // Exempel: transform.position = ny position utanför båten;
        isInBoat = false;
        // Återaktivera rörelsekomponenten när spelaren lämnar båten
        playerRigidbody.velocity = Vector2.zero; // Återställ hastigheten om det behövs
    }

    bool ÄrInutiTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); // Justera radie om det behövs

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(triggerTag))
            {
                return true;
            }
        }

        return false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Exempel på extra logik när objektet befinner sig inuti triggern
        Debug.Log("Objektet är inuti triggern!");
    }
}
