using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager generalmanager;
    public static ReadInfo readfish;
    internal GeneralManager()
    {

    }
    private void Start()
    {
        generalmanager = this;
        readfish = gameObject.GetComponent<ReadInfo>();
    }
}
