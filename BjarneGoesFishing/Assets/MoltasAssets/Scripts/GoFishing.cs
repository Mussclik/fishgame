using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFishing : MonoBehaviour
{
    public Vector3 targetPosition; // Ange m�lkoordinaterna i Unity-redigeraren
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
        if (�rInutiTrigger())
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
                    F�rflyttaObjekt();
                    isInBoat = true;
                }
                else
                {
                    L�mnaB�ten();
                }
            }
        }
    }

    void F�rflyttaObjekt()
    {
        transform.position = targetPosition;
        // Inaktivera r�relsekomponenten n�r spelaren �r i b�ten
        playerRigidbody.velocity = Vector2.zero;
    }

    void L�mnaB�ten()
    {
        // Implementera logik f�r att l�mna b�ten
        // Exempel: transform.position = ny position utanf�r b�ten;
        isInBoat = false;
        // �teraktivera r�relsekomponenten n�r spelaren l�mnar b�ten
        playerRigidbody.velocity = Vector2.zero; // �terst�ll hastigheten om det beh�vs
    }

    bool �rInutiTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); // Justera radie om det beh�vs

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
        // Exempel p� extra logik n�r objektet befinner sig inuti triggern
        Debug.Log("Objektet �r inuti triggern!");
    }
}
