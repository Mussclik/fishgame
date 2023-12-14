using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRod : MonoBehaviour
{
    public float minTime = 0f;
    public float maxTime = 10f;
    public float timer;
    void Start()
    {
        GetComponent<Sprite>();
        timer = Random.Range(minTime, maxTime);
    }
    public void FishingTimer()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer.ToString("0.00"));
        if (timer <= minTime)
        {
            timer = Random.Range(minTime, maxTime);

            Debug.Log("Event");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {

            FishingTimer();

        }


    }
}
