using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private bool debug;
    public ReadFish.FishInfo fishinfo;
    public Sprite image;

    void GetStats(int id)
    {
        ReadFish database = GeneralManager.generalmanager.gameObject.GetComponent<ReadFish>();
        //database.fishies[id];
    }
}
