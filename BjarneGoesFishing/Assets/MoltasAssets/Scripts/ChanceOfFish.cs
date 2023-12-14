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
            Debug.Log("Du f�ngade en Fisk av typen Abborre");
        }
        else if (randomValue <= 0.8f)
        {
            SetFishSprite("FishType2");
            Debug.Log("Du f�ngade en Fisk av typen M�rt");
        }
        else if (randomValue <= 0.85f)
        {
            SetFishSprite("FishType3");
            Debug.Log("Du f�ngade en Fisk av typen G�dda");
        }
        else
        {
            SetFishSprite("FishType4");
            Debug.Log("Du f�ngade en Fisk av typen Bass");
        }
    }

    void SetFishSprite(string spriteName)
    {
        // Anta att du har en sprite f�r varje fisktyp och dessa sprites finns i Resources-mappen
        Sprite fishSprite = Resources.Load<Sprite>(spriteName);

        // S�tt sprite f�r fisk
        if (fishSprite != null && fishSpriteRenderer != null)
        {
            fishSpriteRenderer.sprite = fishSprite;
        }
    }

}
