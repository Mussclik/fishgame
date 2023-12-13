using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LerpScript
{
    #region FugoidRotationVars
    [SerializeField]
    private AnimationCurve rotationCurve;
    [SerializeField] public float rotationDuration;
    [SerializeField] private float elapsedTime;
    public Vector3 targetRotation;
    public Vector3 forward = new Vector3(5, 5, 0);
    Transform transform;
    [SerializeField] public bool getGlobal = true;

    #endregion

    internal LerpScript(Transform transform)
    {
        this.transform = transform;
    }


    #region FugoidRotation
    public void UpdateRotation()
    {
        if (getGlobal)
        {
            rotationCurve = GeneralManager.curve;
            rotationDuration = GeneralManager.curveDuration;
        }


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

        Debug.DrawRay(transform.position, transform.TransformDirection(forward), Color.red);
        Debug.DrawRay(transform.position, newtransform.transform.TransformDirection(forward), Color.blue);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        MonoBehaviour.Destroy(newtransform);

    }

    public void GiveNewInfo(Transform newTransform, Vector3 desiredRotation)
    {
        targetRotation = desiredRotation;
        transform = newTransform;
        elapsedTime = 0f;
    }

    public Vector3 RotateTowards(Transform t1, Transform t2)
    {
        Vector3 rotationTargetVector3 = t2.position - t1.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(rotationTargetVector3, new Vector3(1,1,0));
        rotationTargetVector3 = rotationToTarget.eulerAngles;


        return rotationTargetVector3;
    }
    #endregion

}
