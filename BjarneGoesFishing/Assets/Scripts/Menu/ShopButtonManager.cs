using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonManager : MonoBehaviour
{
    int selectionID = 0;
    Image image;
    [SerializeField] Color selected;
    [SerializeField] Color unselected;
    [SerializeField] GameObject selector;
    [SerializeField] List<UnityEngine.UI.Button> arrows;
    [SerializeField] List<UnityEngine.UI.Button> buttons;
    [SerializeField] List<KeyCode> keycodes;
    [SerializeField] TextMeshProUGUI displaymonye;
    Store store;

    private void Start()
    {
        store = GeneralManager.generalmanager.gameObject.GetComponent<Store>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(keycodes[0]) && selectionID !< -1) //left
        {
            Previous();
            UpdateSelected();
        }
        if (Input.GetKeyDown(keycodes[2]) && selectionID! > buttons.Count) // right
        {
            Next();
            UpdateSelected();
        }
        if (Input.GetKeyDown(keycodes[1]))
        {
            if (selectionID == -2)
            {
                
                store.Close();
            }
            if (selectionID == -1)
            {
                store.Previous();
            }
            if (selectionID > -1 && selectionID < buttons.Count)
            {
                store.ButtonBuy(selectionID);
            }
            if (selectionID == buttons.Count)
            {
                store.Next();
            }
        }
    }


    private void Next()
    {
        selectionID += 1;
    }
    private void Previous()
    {
        selectionID -= 1;
    }
    private void UpdateSelected()
    {
        
    }

}
