using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonManager : MonoBehaviour
{
    int selectionID = 0;

    [SerializeField] GameObject selector;
    [SerializeField] List<UnityEngine.UI.Button> arrows;
    [SerializeField] List<UnityEngine.UI.Button> buttons;
    [SerializeField] List<KeyCode> keycodes;

    private void Update()
    {
        if (Input.GetKeyDown(keycodes[0]) && selectionID !< 0) //left
        {
            Previous();
        }
    }


    private void Next()
    {

    }
    private void Previous()
    {

    }


}
