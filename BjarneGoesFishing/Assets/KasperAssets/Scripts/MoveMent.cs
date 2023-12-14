using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D bjarne;


    // Start is called before the first frame update
    void Start()
    {
        bjarne = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moving = new Vector2 (horizontalInput, 0);
        bjarne.velocity = new Vector2(moving.x * speed, moving.y * speed);
    }
}
