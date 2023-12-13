using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Fish : MonoBehaviour
{
    public int id;
    [SerializeField] private DebugVars debug = new DebugVars();
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
        debug.AddToAll(5);
    }
    private void OnEnable()
    {
        hook = GameObject.FindWithTag("hook").transform;
    }

    void Update()
    {
        lerpScript.UpdateRotationZ();
        if (debug.bools[0])
        {
            Movement();
            debug.timers[0].Update();
            
            if (debug.timers[0].Check())
            {
                debug.timers[0].Start(debug.ints[0]);
                lerpScript.RotateZ(debug.vector3s[0].z);
            }
            Debug.DrawLine(transform.position, debug.vector3s[0], Color.blue);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 5), Color.red);
        }
        else if (attract)
        {
            Debug.DrawRay(transform.position, hook.position - transform.position, Color.magenta); //it works
            //RotationTimer();
            RotateTowardsObject(hook,fugoidTimer);
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
        lerpScript.NewRotationObject(new Vector3(0, 0, startrotation));
        yield return new WaitForSeconds(time);
        caught = false;
        fishinfo.speed -= 5;
        lerpScript.getGlobal = true;
    }
    public void Catch()
    {
        caught = true;
        lerpScript.getGlobal = false;
    }
    private void Fugoid(float range, float baserotation, TimerTest timer)
    {
        timer.Update();
        if (timer.Check())
        {
            timer.Restart();
            float newDirection;
            if (Increasing)
            {
                Increasing = false;
                newDirection = baserotation + range + 1f;
                lerpScript.RotateZ(newDirection);
            }
            else
            {
                Increasing = true;
                newDirection = baserotation - range - 1f;
                lerpScript.RotateZ(newDirection);
            }


            /*
            if (Increasing)
            {
                newvector = new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        range + 1f + baserotation // make this shit adjustable, specifically the -45f
                   );
                Increasing = false;
                lerpScript.NewRotationObject(newvector);
            }
            else
            {
                newvector = new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        -range - 1f + baserotation
                   );
                Increasing = true;
                lerpScript.NewRotationObject(newvector);
            }
            */
            Debug.Log(newDirection.ToString() + " fugoid newvector");
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
    private void RotateTowardsObject(Transform objectToGo, TimerTest timer)
    {
        timer.Update();
        if (timer.Check())
        {
            timer.Restart();
            lerpScript.RotateZ(objectToGo);
        }
    }
    private void RotationTimer(Vector3 targetrotation)
    {
        caughtRotationTimer.Update();
        if (caughtRotationTimer.Check())
        {
            caughtRotationTimer.Restart();

            lerpScript.NewRotationObject(targetrotation);
        }
    }

    public static float AbsRotation(float value)
    {
        value %= value;
        if (value < 0)
        {
            value += 360;
        }
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
