using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScriptInput : MonoBehaviour
{
    [SerializeField] GameObject menu;
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }
}
