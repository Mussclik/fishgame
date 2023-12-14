using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movingWorm : MonoBehaviour
{


    public Transform wormHitBox;
    public Transform upperTransForm;
    public Transform lowerTransForm;
    public bool caughtFish = false;
    public float moveSpeed = 3f;
    private bool movingUp = true;
    
    // Start is called before the first frame update
    void Start()
    {
        SetPosition(upperTransForm, new Vector2(0.0f, -0.77f));
        SetSecondPosition(lowerTransForm, new Vector2(0.0f, -1.34f));
        

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
        if (wormHitBox.position.y >= lowerTransForm.position.y && wormHitBox.position.y <= upperTransForm.position.y && Input.GetKeyDown(KeyCode.E))
        {
            caughtFish = true;
            Debug.Log("You Caught The Fish!");
        }


       
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= 1.68)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            if (transform.position.y <= -4.42)
            {
                movingUp = true;
            }

        }

    }

    
}
