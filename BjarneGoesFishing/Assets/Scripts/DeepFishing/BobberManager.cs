using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BobberManager : MonoBehaviour
{
    [SerializeField] internal int currentTier;
    [SerializeField] UnityEngine.Transform lineOffset;
    [SerializeField] UnityEngine.Transform returnPoint;
    [SerializeField] public bool caughtFish;
    [SerializeField] bool recentFailedCatch;
    [SerializeField] bool movement;
    TimerTest timer = new TimerTest(3);
    [SerializeField] float currentDepth;
    [SerializeField] TextMeshProUGUI depthMeter;

    void Start()
    {
    }

    void Update()
    {
        currentDepth = Vector3.Distance(transform.position, new Vector3(transform.position.x, 0, transform.position.z)) * 0.5f;
        depthMeter.text = "Current Depth: " + currentDepth.ToString("0.0") + "m";
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
