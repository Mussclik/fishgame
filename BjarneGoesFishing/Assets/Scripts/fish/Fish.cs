using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Fish : MonoBehaviour
{
    public int id;
    [SerializeField] private bool debug;
    [SerializeField] private bool Increasing;
    [SerializeField] private bool setValue;
    [SerializeField] public bool attract;

                     public SpriteRenderer spriteRenderer;
    [SerializeField] internal bool caught = false;
    [SerializeField] public FishInfo fishinfo;
    [SerializeField] public Transform hook;
    [SerializeField] private Transform mouth;
    [SerializeField] private LerpScript lerpScript;




    #region FugoidMethodVars
    [SerializeField] private GameObject newgameobject;
    [SerializeField, Range(0, 360)] private float startrotation;
    [SerializeField] private TimerTest caughtRotationTimer;
    [SerializeField] private TimerTest fugoidTimer;
    #endregion

    private void Start()
    {
        caughtRotationTimer = new TimerTest(2);
        fugoidTimer = new TimerTest(2);
        startrotation = transform.rotation.eulerAngles.z;
        lerpScript = new LerpScript(transform);
    }
    private void OnEnable()
    {
        hook = GameObject.FindWithTag("hook").transform;
    }

    void Update()
    {
        lerpScript.UpdateRotation();
        if (debug)
        {

        }
        else if (attract)
        {
            Debug.DrawRay(transform.position, hook.position-transform.position, Color.black); //it works
            Debug.DrawRay(transform.position, hook.position - transform.position, Color.magenta); //it works
            //RotationTimer();
            Movement();
        }
        else if (!caught)
        {
            Fugoid(fishinfo.phugoidRange, startrotation, fugoidTimer);
            Movement();
        }
        else
        {

            //RotationTimer();
            transform.position = Vector3.Lerp(transform.position, new Vector3(hook.position.x,hook.position.y - 3, hook.position.z), 0.5f);
        }
        
    }
    public void Release()
    {
        StartCoroutine(ReleaseWait(5));
    }
    IEnumerator ReleaseWait(float time)
    {
        fishinfo.speed += 5;
        lerpScript.GiveNewInfo(transform, new Vector3(0, 0, startrotation));
        yield return new WaitForSeconds(time);
        caught = false;
        fishinfo.speed -= 5;
        lerpScript.getGlobal = true;
    }
    public void Catch()
    {
        caught = true;
        lerpScript.getGlobal = false;
        lerpScript.rotationDuration = 2;
    }
    private void Fugoid(float range, float baserotation, TimerTest timer)
    {
        fugoidTimer.Update();
        if (fugoidTimer.Check())
        {
            fugoidTimer.Restart();
            if (Increasing)
            {
                Increasing = false;
                lerpScript.GiveNewInfo(transform, new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        range + 1f + baserotation // make this shit adjustable, specifically the -45f
                   ));
            }
            else
            {
                Increasing = true;
                lerpScript.GiveNewInfo(transform, new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        -range - 1f + baserotation
                   ));
            }
        }
        /*
        //Debug.Log(transform.rotation.eulerAngles.z + "euler Z");
        //float max = -45f + fishinfo.phugoidRange;
        //Debug.Log(AbsRotation(max) + "max phugoid");
        //float min = -45f - fishinfo.phugoidRange;
        //Debug.Log(AbsRotation(min) + "min phugoid");
        //if (Increasing)
        //{
        //    if (!setValue)
        //    {
        //        setValue = true;
        //        lerpScript.GiveNewInfo(transform, new Vector3
        //            (
        //                transform.rotation.eulerAngles.x, 
        //                transform.rotation.eulerAngles.y, 
        //                max + 1f
        //            ));
        //    }
        //    if (transform.rotation.eulerAngles.z > max)
        //    {
        //        Increasing = false;
        //        setValue = false;
        //    }
        //}

        //if (!Increasing)
        //{
        //    if (!setValue)
        //    {
        //        setValue = true;
        //        lerpScript.GiveNewInfo(transform, new Vector3
        //            (
        //                transform.rotation.eulerAngles.x,
        //                transform.rotation.eulerAngles.y,
        //                min - 1f
        //            ));
        //    }
        //    if (transform.rotation.eulerAngles.z < min)
        //    {
        //        Increasing = false;
        //        setValue = false;
        //    }
        //}
        /*
        ////GameObject debugobject = new GameObject();
        //float newRotation = -45f; // an angle of -45 makes it straight
        //if (Increasing && transform.rotation.eulerAngles.z > newRotation + fishinfo.phugoidRange)
        //{
        //    Increasing = !Increasing;
        //    newRotation -= fishinfo.phugoidRange;
        //    newRotation -= 1;
        //    lerpScript.GiveNewInfo(transform, new Vector3(0, 0, newRotation));
        //}
        //else if (!Increasing && transform.rotation.eulerAngles.z < newRotation - fishinfo.phugoidRange)
        //{
        //    Increasing = !Increasing;
        //    newRotation += fishinfo.phugoidRange;
        //    newRotation += 1;
        //    lerpScript.GiveNewInfo(transform, new Vector3(0, 0, newRotation));
        //}
       
        //debugobject.transform.rotation = transform.rotation;
        //debugobject.transform.rotation = Quaternion.Euler(new Vector3(0,0, -45f + fishinfo.phugoidRange));
        //Debug.DrawRay(transform.position, debugobject.transform.TransformDirection(new Vector3(4,4,0)), Color.yellow);
        //debugobject.transform.rotation = transform.rotation;
        //debugobject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45f - fishinfo.phugoidRange));
        //Debug.DrawRay(transform.position, debugobject.transform.TransformDirection(new Vector3(4, -4, 0)), Color.yellow);
        //Destroy(debugobject);

        */
    }
    private void RotationTimer(Vector3 targetrotation)
    {
        caughtRotationTimer.Update();
        if (caughtRotationTimer.Check())
        {
            caughtRotationTimer.Restart();

            lerpScript.GiveNewInfo(transform, targetrotation);
        }
    }

    public static float AbsRotation(float value)
    {
        value %= value;
        return value;
    }

    public void UpdateInfo(int id)
    {
        fishinfo = GeneralManager.readfish.fishList[id];
        spriteRenderer.sprite = GeneralManager.readfish.fishSprites[id];
        newgameobject.transform.localPosition = new Vector3(fishinfo.speed, fishinfo.speed, 0);
    }
    public FishInfo RetrieveInfo()
    {
        return fishinfo;
    }

    public void Movement()
    {
        if (!caught)
        {
            transform.position = Vector3.Lerp(transform.position, newgameobject.transform.position, 0.3f * Time.deltaTime);
        }
        else
        {
            
        }
        
    }
    //have to add that bullshitusaoihfiho

}
