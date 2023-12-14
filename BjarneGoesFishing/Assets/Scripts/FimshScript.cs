using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FimshScript : MonoBehaviour
{
    public Collider2D maxHeight;
    public Collider2D minHeight;
    public Collider2D hitBarBox;
    public Sprite playerHitBar;
    public Sprite hitBar;
    public Image fishingBar;
    public Image fishingHitBar;
    public Vector2 fishingHitBarPosition;
    public Vector2 playerHitBarPosition;
    ChanceOfFish fishming = new ChanceOfFish();
    // Start is called before the first frame update
    void Start()
    {
        fishingBar = GetComponent<Image>();
        fishingHitBar = GetComponent<Image>();
        playerHitBar = GetComponent<Sprite>();
        hitBar = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            fishming.GenerateFish();

        }
        

    }

    public bool IsMax(BoxCollider2D maxheight, BoxCollider2D hitbarbox)
    {
        Bounds maxBounds = maxheight.bounds;
        Bounds hitBounds = hitbarbox.bounds;

        return hitBounds.min.x >= maxBounds.min.x && hitBounds.min.y >= maxBounds.min.y && hitBounds.max.x <= maxBounds.max.x && hitBounds.max.y <= maxBounds.max.y;





    }








}
