using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Fish : MonoBehaviour
{
    public int id;
    [SerializeField] public FishInfo fishinfo;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private bool debug;
    [SerializeField]
    LerpScript lerpScript;

    #region FugoidMethodVars
    [SerializeField] private bool Increasing;
    [SerializeField] private bool setValue;
    [SerializeField] GameObject newgameobject;


    float fugoidTimer = 0;
    float fugoidMaxTime = 2;
    #endregion

    private void Start()
    {
        lerpScript = new LerpScript(transform);
        Debug.Log(transform.TransformDirection(lerpScript.forward));
    }

    void Update()
    {
        lerpScript.UpdateRotation();
        Fugoid();

        if (debug)
        {
            debug = false;
            GetInfo(id);
        }
        Movement();


    }

    private void Fugoid()
    {
        fugoidTimer += Time.deltaTime;
        if (fugoidTimer > fugoidMaxTime)
        {
            fugoidTimer = 0;
            if (Increasing)
            {
                Increasing = false;
                lerpScript.GiveNewInfo(transform, new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        fishinfo.phugoidRange + 1f - 45f
                   ));
            }
            else
            {
                Increasing = true;
                lerpScript.GiveNewInfo(transform, new Vector3
                    (
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        -fishinfo.phugoidRange - 1f - 45f
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

    public float AbsRotation(float value)
    {
        while (value > 360)
        {
            value -= 360;
        }
        while (value < 0)
        {
            value += 360;
        }
        return value;
    }

    public void GetInfo(int id)
    {
        fishinfo = GeneralManager.readfish.fishList[id];
        spriteRenderer.sprite = GeneralManager.readfish.fishSprites[id];
        newgameobject.transform.localPosition = new Vector3(fishinfo.speed, fishinfo.speed, 0);
    }

    public void Movement()
    {
        
        transform.position = Vector3.Lerp(transform.position, newgameobject.transform.position, 0.3f * Time.deltaTime);
    }
    //have to add that bullshitusaoihfiho

}
