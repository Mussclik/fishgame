using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputManager : MonoBehaviour
{
    public GameObject ButtonInputManager;
    public int gameSceneID;
    public bool creditsClosed;
    void Start()
    {
        creditsClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && creditsClosed)
        {
            ButtonInputManager.GetComponent<ButtonManager>().StartButton(gameSceneID);
        }
        else if (Input.GetKey(KeyCode.Alpha2) && creditsClosed)
        {
            ButtonInputManager.GetComponent<ButtonManager>().CreditsButton();
            creditsClosed = false;
        }
        else if (Input.GetKey(KeyCode.Alpha3) && creditsClosed)
        {
            ButtonInputManager.GetComponent<ButtonManager>().QuitButton();
        }
        else if (Input.GetKey(KeyCode.Alpha2) && creditsClosed == false)
        {
            ButtonInputManager.GetComponent<ButtonManager>().CreditsBackButton();
            creditsClosed = true;
        }
    }
}
