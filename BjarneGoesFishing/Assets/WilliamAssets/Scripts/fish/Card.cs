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
    public TextMeshPro value;
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

    public void UpdateInfo()
    {
        id = fishinfo.id;
        value.text = fishinfo.value.ToString();
        fishinfo = ReadInfo.fishList2[id];
        namerenderer.text = fishinfo.name;
        descriptionRenderer.text = fishinfo.description;
        spriteRenderer.sprite = ReadInfo.fishSprites2[id];
    }
    public void UpdateInfo(int id)
    {
        value.text = fishinfo.value.ToString();
        fishinfo = ReadInfo.fishList2[id];
        namerenderer.text = fishinfo.name;
        descriptionRenderer.text = fishinfo.description;
        spriteRenderer.sprite = ReadInfo.fishSprites2[id];
    }
    public void UpdateInfo(FishInfo fishinfo, Sprite sprite)
    {
        value.text = fishinfo.value.ToString();
        namerenderer.text = fishinfo.name;
        descriptionRenderer.text = fishinfo.description;
        spriteRenderer.sprite = sprite;
    }
}
