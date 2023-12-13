using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

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
        Vector3 newMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(newMovement.normalized * Time.deltaTime * 10);
    }

    void ResetBobber()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.ToLower() == "fish")
        {
            Fish fish = collision.GetComponent<Fish>();
            if (currentTier >= fish.fishinfo.tier)
            {
                fish.attract = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
