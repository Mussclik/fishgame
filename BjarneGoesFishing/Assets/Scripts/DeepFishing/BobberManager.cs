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
    TimerTest lerpTimer = new TimerTest(0);
    [SerializeField] float currentDepth;
    [SerializeField] TextMeshProUGUI depthMeter;

    [SerializeField] Vector3 minClamp;
    [SerializeField] Vector3 maxClamp;
    [SerializeField] GameObject fishCatcher;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] UnityEngine.Transform moveToHook;
    
    

    void Start()
    {
        moveToHook = new GameObject().transform;
        fishCatcher.SetActive(false);
    }

    void Update()
    {
        if (!lerpTimer.Check())
        {
            lerpTimer.Update();

            float curveTime = Mathf.Clamp01(lerpTimer.elapsedTime / lerpTimer.Duration);
            float curveValue = animationCurve.Evaluate(curveTime);

            transform.position = Vector3.Lerp(transform.position, moveToHook.position, curveValue);
        }


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

        transform.position = CameraFollowScript.ClampVector3(transform.position ,minClamp, maxClamp);


    }
        
    public void CatchFish()
    {
        caughtFish = true;
        movement = false;
        fishCatcher.SetActive(true);
        movingWorm script = fishCatcher.transform.GetChild(1).gameObject.GetComponent<movingWorm>();
        script.GiveInfo(this, transform);
        moveToHook.position = transform.position;
    }
    public void ReelingFish()
    {
        moveToHook.position += (Vector3.MoveTowards(transform.position, returnPoint.position, 2) - moveToHook.position);
        lerpTimer.Start(1);
    }
    public void FishEscape()
    {
        recentFailedCatch = true;
        movement = true;
        fishCatcher.SetActive(false);

        timer.Restart();
    }
}
