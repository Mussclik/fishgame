using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class movingWorm : MonoBehaviour
{
    public List<Transform> maxTransforms;
    public List<Transform> successTransforms;
    public bool caughtFish = false;
    public float moveSpeed = 3f;
    private bool movingUp = true;

    //devious william hijack
    [SerializeField] Transform bobber;
    [SerializeField] BobberManager bobberinfo;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void GiveInfo(BobberManager info, Transform bobber)
    {
        this.bobber = bobber;
        bobberinfo = info;
    }

    void SetSecondPosition(Transform secondTransformTomodify, Vector2 secondNewPosition)
    {
        secondTransformTomodify.position = secondNewPosition;
    }

   void SetPosition(Transform transformToModify, Vector2 newPosition)
    {
        transformToModify.position = newPosition;
    }


    // Update is called once per frame
    void Update()
    {
        //if (wormHitBox.position.y >= lowerTransForm.position.y && wormHitBox.position.y <= upperTransForm.position.y && Input.GetKeyDown(KeyCode.E))
        //{
        //    caughtFish = true;
        //    Debug.Log("You Caught The Fish!");
        //}
        if (transform.position.y <= successTransforms[1].position.y && transform.position.y >= successTransforms[0].position.y && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Reelingfish");
            bobberinfo.ReelingFish();
        }
       
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= maxTransforms[1].position.y)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            if (transform.position.y <= maxTransforms[0].position.y)
            {
                movingUp = true;
            }

        }

    }

    
}
