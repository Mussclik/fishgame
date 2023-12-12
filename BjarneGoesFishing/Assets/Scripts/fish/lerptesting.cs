using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerptesting : MonoBehaviour
{
    //i uh, "outsourced" this script to chatgpt




    public AnimationCurve rotationCurve;
    [SerializeField, Range(0,5)] public float rotationDuration = 2f;
    private float elapsedTime = 0f;
    public Vector3 targetRotation;
    [SerializeField]public Vector3 rayTest;
    [SerializeField, Range(0,360)] public float rayx, rayy, rayz;
    [SerializeField, Range(0, 360)] float targetZ;
    [SerializeField] bool debugtest;

    void Start()
    {
    }

    void Update()
    {
        rayTest = new Vector3(rayx, rayy, rayz);
        if (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;

            float curveTime = Mathf.Clamp01(elapsedTime / rotationDuration);
            float curveValue = rotationCurve.Evaluate(curveTime);

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), curveValue);

            transform.rotation = newRotation;
            
        }
        GameObject newtransform = new GameObject();
        newtransform.transform.rotation = transform.rotation;
        newtransform.transform.rotation = Quaternion.Euler(targetRotation);
            
        Debug.DrawRay(transform.position, transform.TransformDirection(rayTest), Color.red);
        Debug.DrawRay(transform.position, newtransform.transform.TransformDirection(rayTest), Color.blue);

        Destroy(newtransform);

        if (debugtest)
        {
            debugtest = false;
            Vector3 newDesiredRotation = new Vector3(0f, 0f, targetZ);
            RotateTo(newDesiredRotation);
        }
    }
    public void RotateTo(Vector3 desiredRotation)
    {
        targetRotation = desiredRotation;
        elapsedTime = 0f;
    }










    //[SerializeField] AnimationCurve curve;
    //[SerializeField, Range(0, 20)] float time;
    //[SerializeField] float curvetime; 
    //[SerializeField, Range(0, 360)] float targetRotationZ;
    //[SerializeField] Vector3 targetRotation;
    //[SerializeField, Range(0, 360)] float realRotation;


    //// Update is called once per frame
    //void Update()
    //{
    //    realRotation = gameObject.transform.rotation.eulerAngles.z;

    //    targetRotation = new Vector3(transform.rotation.x, transform.rotation.y, targetRotationZ);
    //    gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * time);

    //}
}
