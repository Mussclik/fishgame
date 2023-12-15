using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public float horizontal1SpeedMultiplier = 1.5f;
    public bool stopped;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!stopped)
        {
            // Horizontal movement
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput >= 0.1f)
            {
                //spriteRenderer.flipX = true;
                animator.SetInteger("State", 1);
            }
            else if (horizontalInput <= -0.1f)
            {
                //spriteRenderer.flipX = false;
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 0);
            }
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

            // Apply horizontal movement
            transform.Translate(movement);

            //// Horizontal1 movement (additional speed)
            //float horizontal1Input = Input.GetAxis("Horizontal1");
            //Vector3 horizontal1Movement = new Vector3(horizontal1Input, 0f, 0f) * speed * horizontal1SpeedMultiplier * Time.deltaTime;

            //// Apply horizontal1 movement
            //transform.Translate(horizontal1Movement);


        }

    }
}

