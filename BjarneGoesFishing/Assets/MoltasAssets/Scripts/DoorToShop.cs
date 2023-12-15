using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToShop : MonoBehaviour
{
    [SerializeField] bool LoadScene;
    [SerializeField] int scene;
    [SerializeField] Store store;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LoadScene)
        {
            SceneManager.LoadScene(scene);
        }
        else if (Input.GetKeyDown(KeyCode.E) && !LoadScene)
        {
            store.Open();
        }
        // Check if the collider belongs to the player (you can customize this check as needed)


    }
}
