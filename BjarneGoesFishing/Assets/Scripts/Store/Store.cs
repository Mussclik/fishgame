using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private bool isOpen;
    public void Activate()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
    private void Close()
    {

    }
    private void Open()
    {
        
    }
}
