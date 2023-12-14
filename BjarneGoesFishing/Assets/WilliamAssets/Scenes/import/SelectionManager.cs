using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Button quitButton;
    public Button creditsBackButton;
    private Button[] mainMenuButtons = new Button[3];
    private Button currentButton;
    public GameObject selectionMarker;
    public GameObject creditsScreen;
    public int currentButtonID = 0;
    public EventSystem eventSystem;
    public int selectorOffset = 500;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode EnterKey;

    //image files
    public GameObject[] mainMenuImages;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenuButtons[0] = startButton;
        mainMenuButtons[1] = creditsButton;
        mainMenuButtons[2] = quitButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(downKey))
        {
            if (currentButtonID == mainMenuButtons.Length - 1) //if on exit, set to start
            {

                
                currentButtonID = 0;

                //coding is my passion -william, 2023
                mainMenuImages[4].SetActive(true);
                mainMenuImages[4 + 1].SetActive(false);
                mainMenuImages[0].SetActive(false);
                mainMenuImages[0 + 1].SetActive(true);
            }
            else
            {
                currentButtonID += 1;

                if (currentButtonID == 1) //there is probably such a more effecient way but im birdbrain
                {
                    //go from start to credits
                    mainMenuImages[0].SetActive(true);
                    mainMenuImages[0 + 1].SetActive(false);
                    mainMenuImages[2].SetActive(false);
                    mainMenuImages[2 + 1].SetActive(true);
                }
                else
                {
                    //credits to exit
                    mainMenuImages[2].SetActive(true);
                    mainMenuImages[2 + 1].SetActive(false);
                    mainMenuImages[4].SetActive(false);
                    mainMenuImages[4 + 1].SetActive(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(upKey))
        {
            if (currentButtonID == 0)//if on start then make to exit
            {
                currentButtonID = mainMenuButtons.Length - 1;


                mainMenuImages[4].SetActive(!true);
                mainMenuImages[4 + 1].SetActive(!false);
                mainMenuImages[0].SetActive(!false);
                mainMenuImages[0 + 1].SetActive(!true);
            }
            else
            {
                currentButtonID -= 1;

                if (currentButtonID == 1) //if gone from exit to credits
                {
                    mainMenuImages[4].SetActive(true);
                    mainMenuImages[4 + 1].SetActive(false);
                    mainMenuImages[2].SetActive(false);
                    mainMenuImages[2 + 1].SetActive(true);
                }
                else //if gone from credits to start
                {
                    //this code is specially lazy
                    mainMenuImages[0].SetActive(!true);
                    mainMenuImages[0 + 1].SetActive(!false);
                    mainMenuImages[2].SetActive(!false);
                    mainMenuImages[2 + 1].SetActive(!true);
                }
            }
        }
        currentButton = mainMenuButtons[currentButtonID];
        Vector3 currentButtonPos = currentButton.gameObject.transform.position;

        if (creditsScreen.activeInHierarchy)
        {
            currentButton = creditsBackButton;
            currentButtonPos = creditsBackButton.gameObject.transform.position;
            
        }
        // selectionMarker.transform.position = new Vector3(currentButtonPos.x -selectionOffset, currentButtonPos.y, currentButtonPos.z);
        selectionMarker.transform.position = new Vector3(selectionMarker.transform.position.x, currentButtonPos.y, currentButtonPos.z);
            
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(EnterKey))
        {
            currentButton.onClick.Invoke();
            
        }
    }
}
