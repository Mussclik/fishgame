using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] Vector2 rangeX;
    [SerializeField] Vector2 rangeY;
    [SerializeField] List<GameObject> list;

    private void Start()
    {
        rangeX = SortVector(rangeX);
        rangeY = SortVector(rangeY);

        for(int i = 0; i < amount; i++)
        {
            Vector3 newposition = new Vector3(Random.Range(rangeX.x, rangeX.y + 1), Random.Range(rangeY.x, rangeY.y+1),0);
            Instantiate(list[Random.Range(0, list.Count)], newposition, Quaternion.identity, transform);
        }
        
    }

    static Vector2 SortVector(Vector2 inputVector)
    {
        float x = Mathf.Min(inputVector.x, inputVector.y);
        float y = Mathf.Max(inputVector.x, inputVector.y);

        return new Vector2(x, y);
    }




}
