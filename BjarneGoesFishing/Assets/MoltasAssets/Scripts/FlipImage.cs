using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipImage : MonoBehaviour
{

    void Update()
    {
        // Check for input to flip the image right (horizontally)
        if (Input.GetKeyDown(KeyCode.A))
        {
            FlipRight();
        }

        // Check for input to flip the image left (horizontally)
        if (Input.GetKeyDown(KeyCode.D))
        {
            FlipLeft();
        }
    }

    void FlipRight()
    {
        // Flip the image horizontally to the right
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void FlipLeft()
    {
        // Flip the image horizontally to the left
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }
}