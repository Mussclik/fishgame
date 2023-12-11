using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public class ThrowRod : MonoBehaviour
    {
        public float minTime = 0f;
        public float maxTime = 10f;
        public float timer;

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
                Debug.Log("Event");
            }


        }



        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                FishingTimer();

            }


        }
    }





    [SerializeField] private bool debug;
    public ReadFish.FishInfo fishinfo;
    public Sprite image;

    void GetStats(int id)
    {
        ReadFish database
    }
}
