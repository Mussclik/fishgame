using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform transform1;
    [SerializeField] Transform transform2;
    [SerializeField][Range(0, 30)] public float followSpeed;
    internal Vector3 followingDirection;
    [SerializeField] bool lockXAxis, lockYAxis, lockZAxis;
    Collider2D collider2d;
    [SerializeField] Vector3 maxPos, minPos;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameVariables.playerTransform;
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axislock = transform.position;
        if (transform2 != null)
        {
            Vector3 directionT1toT2 = transform2.position - transform1.position;

            Vector3 pointBetweenTranforms = directionT1toT2 + transform1.position;

            followingDirection = pointBetweenTranforms - transform.position;

            transform.Translate(new Vector2(followingDirection.x, followingDirection.y) * followSpeed * Time.deltaTime);
        }
        else if (transform1 != null)
        {
            transform.position = Vector3.Lerp(transform.position, transform1.position, followSpeed * 0.8f * Time.deltaTime);
        }

        if (lockXAxis)
        {
            transform.position = new Vector3(axislock.x, transform.position.y, transform.position.z);
        }
        if (lockYAxis) 
        { 
            transform.position = new Vector3(transform.position.x, axislock.y, transform.position.z); 
        }
        if (lockZAxis) 
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y, axislock.z); 
        }
        Vector3[] clampVectors = SortVector3Size(minPos, maxPos);
        transform.position = ClampVector3(transform.position, clampVectors[0], clampVectors[1]);
    }

    public static Vector3 ClampVector3(Vector3 vectorToClamp, Vector3 min, Vector3 max)
    {
        float vectorX, vectorY, vectorZ;
        vectorX = Mathf.Clamp(vectorToClamp.x, min.x, max.x);
        vectorY = Mathf.Clamp(vectorToClamp.y, min.y, max.y);
        vectorZ = Mathf.Clamp(vectorToClamp.z, min.z, max.z);
        return new Vector3(vectorX, vectorY, vectorZ);
    }

    public static Vector3[] SortVector3Size(Vector3 vector1, Vector3 vector2)
    {
        float temp;
        if (vector1.x > vector2.x)
        {
            temp = vector2.x;
            vector2.x = vector1.x;
            vector1.x = temp;
        }
        if (vector1.y > vector2.y)
        {
            temp = vector2.y;
            vector2.y = vector1.y;
            vector1.y = temp;
        }
        if (vector1.z > vector2.z)
        {
            temp = vector2.z;
            vector2.z = vector1.z;
            vector1.z = temp;
        }
        Vector3[] returnVectors = new Vector3[2];
        returnVectors[0] = vector1;
        returnVectors[1] = vector2;
        return returnVectors;
    }
}
