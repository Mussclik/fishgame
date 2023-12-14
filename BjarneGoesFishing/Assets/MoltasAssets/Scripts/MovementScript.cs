using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float horizontal1SpeedMultiplier = 1.5f;

    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Apply horizontal movement
        transform.Translate(movement);

        // Horizontal1 movement (additional speed)
        float horizontal1Input = Input.GetAxis("Horizontal1");
        Vector3 horizontal1Movement = new Vector3(horizontal1Input, 0f, 0f) * speed * horizontal1SpeedMultiplier * Time.deltaTime;

        // Apply horizontal1 movement
        transform.Translate(horizontal1Movement);

        
    }
}

