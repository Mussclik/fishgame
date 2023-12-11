using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerptesting : MonoBehaviour
{
    //i uh, "outsourced" this script to chatgpt

    public AnimationCurve rotationCurve;
    [SerializeField, Range(0,5)] public float rotationDuration = 2f;
    private float elapsedTime = 0f;
    private Quaternion startRotation;
    public Vector3 targetRotation;
    [SerializeField, Range(0, 360)] float targetZ;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;

            float curveTime = Mathf.Clamp01(elapsedTime / rotationDuration);
            float curveValue = rotationCurve.Evaluate(curveTime);

            // Use the curve value to interpolate between start and target rotations
            Quaternion newRotation = Quaternion.Lerp(startRotation, Quaternion.Euler(targetRotation), curveValue);

            // Apply the new rotation to the object
            transform.rotation = newRotation;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Example: Rotate to a new desired rotation when the space key is pressed
            Vector3 newDesiredRotation = new Vector3(0f, 0f, targetZ);
            RotateTo(newDesiredRotation);
        }
    }

    // Method to initiate the rotation with a new desired rotation
    public void RotateTo(Vector3 desiredRotation)
    {
        startRotation = transform.rotation;
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
