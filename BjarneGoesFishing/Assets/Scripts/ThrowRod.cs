using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRod : MonoBehaviour
{
    public float minTime = 0f;
    public float maxTime = 10f;
    public float timer;
    ChanceOfFish fishming = new ChanceOfFish();
    public Animation fishRodThrow = null;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Sprite>();
        timer = Random.Range(minTime, maxTime);
    }
    public void FishingTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= minTime)
        {
            timer = Random.Range(minTime, maxTime);
            fishming.GenerateFish();
        }


    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            FishingTimer();
            fishRodThrow.Play();
        }

        
    }
}
