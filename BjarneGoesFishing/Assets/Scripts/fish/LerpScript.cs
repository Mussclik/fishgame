using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LerpScript
{
    #region FugoidRotationVars
    TimerTest timer = new TimerTest(0);
    TimerTest timerZ = new TimerTest(0);
    [SerializeField] private AnimationCurve rotationCurve;
    [SerializeField] public bool getGlobal = true;

    public float targetZ;
    public Vector3 targetRotation;
    //public Vector3 forward = new Vector3(5, 5, 0);
    Transform transform;
    

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
            getGlobal = false;
            rotationCurve = GeneralManager.curve;
            timer.Start(GeneralManager.curveDuration);
        }
        

        if (!timer.Check())
        {
            timer.Update();

            float curveTime = Mathf.Clamp01(timer.elapsedTime / timer.Duration);
            float curveValue = rotationCurve.Evaluate(curveTime);

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), curveValue);

            transform.rotation = newRotation;
        }
        /*
        GameObject newtransform = new GameObject();
        newtransform.transform.rotation = transform.rotation;
        newtransform.transform.rotation = Quaternion.Euler(targetRotation);

        Debug.DrawRay(transform.position, transform.TransformDirection(forward), Color.red);
        Debug.DrawRay(transform.position, newtransform.transform.TransformDirection(forward), Color.blue);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        MonoBehaviour.Destroy(newtransform);
        */
    }

    public void UpdateRotationZ()
    {
        if (getGlobal)
        {
            getGlobal = false;
            rotationCurve = GeneralManager.curve;
            timerZ.Start(GeneralManager.curveDuration);
        }
        if (!timerZ.Check())
        {
            timerZ.Update();

            float curveTime = Mathf.Clamp01(timerZ.elapsedTime / timerZ.Duration);
            float curveValue = rotationCurve.Evaluate(curveTime);

            Vector3 currentRotation = new Vector3(0,0, transform.rotation.eulerAngles.z);
            Vector3 wantedRotation = new Vector3(0, 0, targetZ);

            float newRotationZ = Quaternion.Lerp(Quaternion.Euler(currentRotation), Quaternion.Euler(wantedRotation), curveValue).eulerAngles.z;
            Debug.Log(newRotationZ + " lerpscript updateZ newrotation");
            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotationZ);

            transform.rotation = Quaternion.Euler(newRotation);
        }
    }

    public void NewRotationObject(Vector3 desiredRotation)
    {
        targetRotation = desiredRotation;
        timer.Restart();
    }
    public void RotateZ(float desiredZ)
    {
        targetZ = desiredZ;
        timerZ.Restart();
    }
    public void RotateZ(Transform desiredZTransform)
    {
        // Calculate the direction vector from the fish to the hook
        Vector3 direction = desiredZTransform.position - transform.position;

        // Calculate the rotation to look at the hook
        Quaternion rotationToTarget = Quaternion.LookRotation(Vector3.forward, direction);

        // Calculate the angle between the current right direction and the target direction
        float angle = Vector3.SignedAngle(transform.right, direction.normalized, Vector3.forward);

        // Set the targetZ by adding the angle difference to the current rotation
        targetZ = transform.eulerAngles.z + angle;
        timerZ.Restart();
    }

    public Vector3 GetDesiredPosition(Transform objectToRotateTo)
    {
        Vector3 rotationTargetVector3 = objectToRotateTo.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(rotationTargetVector3, new Vector3(1,1,0));
        rotationTargetVector3 = rotationToTarget.eulerAngles;
        return rotationTargetVector3;
    }
    public Vector3 GetDesiredPosition(Vector3 objectToRotateTo)
    {
        Vector3 rotationTargetVector3 = objectToRotateTo - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(rotationTargetVector3, new Vector3(1, 1, 0));
        rotationTargetVector3 = rotationToTarget.eulerAngles;
        return rotationTargetVector3;
    }

    #endregion

}
