using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BobberManager : MonoBehaviour
{
    [SerializeField] internal int currentTier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBobber()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            if (currentTier >= collision.GetComponent<Fish>().fishinfo.tier)
            {

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
