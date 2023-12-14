using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private bool debug;
    public int id;
    public FishInfo fishinfo; //dont look at this, i cry everytime
    public SpriteRenderer spriteRenderer;
    public TextMeshPro namerenderer;
    public TextMeshPro descriptionRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            debug = false;
            UpdateInfo(id);
        }
    }

    void UpdateInfo(int id)
    {
        fishinfo = GeneralManager.readfish.fishList[id];
        namerenderer.text = fishinfo.name;
        descriptionRenderer.text = fishinfo.description;
        spriteRenderer.sprite = GeneralManager.readfish.fishSprites[id];
    }
}
