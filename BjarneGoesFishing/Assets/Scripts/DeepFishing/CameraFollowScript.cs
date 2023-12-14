using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform transform1;
    [SerializeField] Transform transform2;
    [SerializeField][Range(0, 10)] public float followSpeed;
    internal Vector3 followingDirection;
    [SerializeField] bool lockXAxis, lockYAxis, lockZAxis;
    Collider2D collider2d;

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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Wall")) 
        {
            Physics2D.IgnoreCollision(this.collider2d, collision.collider);
        }
    }
}
