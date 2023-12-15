using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BjarnDistance : MonoBehaviour
{
    [SerializeField] Transform bjarn;
    [SerializeField] float distance;
    [SerializeField] Store store;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, bjarn.position);
        if (distance < 4.7)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                store.Open();
            }
        }
    }

}
