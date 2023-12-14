using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceOfFish : MonoBehaviour
{

    public SpriteRenderer fishSpriteRenderer;


    void Start()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateFish();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateFish();
        }

    }

    public void GenerateFish()
    {
        float randomValue = Random.value;

        if (randomValue <= 0.6f)
        {
            SetFishSprite("FishType1");
            Debug.Log("Du fångade en Fisk av typ 1!");
        }
        else if (randomValue <= 0.8f)
        {
            SetFishSprite("FishType2");
            Debug.Log("Du fångade en Fisk av typ 2!");
        }
        else if (randomValue <= 0.85f)
        {
            SetFishSprite("FishType3");
            Debug.Log("Du fångade en Fisk av typ 3!");
        }
        else
        {
            SetFishSprite("FishType4");
            Debug.Log("Du fångade en Fisk av typ 4!");
        }
    }

    void SetFishSprite(string spriteName)
    {
        // Anta att du har en sprite för varje fisktyp och dessa sprites finns i Resources-mappen
        Sprite fishSprite = Resources.Load<Sprite>(spriteName);

        // Sätt sprite för fisk
        if (fishSprite != null && fishSpriteRenderer != null)
        {
            fishSpriteRenderer.sprite = fishSprite;
        }
    }

}
