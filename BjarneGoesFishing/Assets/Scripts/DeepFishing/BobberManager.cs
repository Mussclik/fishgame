using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class BobberManager : MonoBehaviour
{
    [SerializeField] internal int currentTier;
    [SerializeField] Transform lineOffset;
    [SerializeField] Transform returnPoint;
    [SerializeField] public bool caughtFish;
    [SerializeField] bool recentFailedCatch;
    [SerializeField] bool movement;
    TimerTest timer = new TimerTest(3);
    void Start()
    {
        
    }

    void Update()
    {

        if (movement)
        {
            Vector3 newMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.Translate(newMovement.normalized * Time.deltaTime * 10);
            lineOffset.position = new Vector3(transform.position.x * 0.5f, lineOffset.position.y, lineOffset.position.z);
        }

        if (recentFailedCatch)
        {
            timer.Update();
            if (timer.Check())
            {
                timer.Restart();
                caughtFish = false;

            }
        }

    }
        
    public void CatchFish()
    {
        
    }
    public void ReelingFish()
    {
        transform.position = Vector3.MoveTowards(transform.position, returnPoint.position, 3 * Time.deltaTime);
    }
    public void FishEscape()
    {
        recentFailedCatch = true;
        timer.Restart();
    }
}
