using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager generalmanager;
    internal GeneralManager()
    {
        GeneralManager.generalmanager = this;
    }
    private void Start()
    {
        
    }
}
