using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private bool debug;
    public int id;
    public FishInfo fishinfo; //dont look at this, i cry everytime
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (debug)
        {
            debug = false;
            GetInfo(id);

        }
    }

    public void GetInfo(int id)
    {
        fishinfo = GeneralManager.readfish.fishList[id];
        spriteRenderer.sprite = GeneralManager.readfish.fishSprites[id];
    }
    
    public void Movement()
    {

    }

}
