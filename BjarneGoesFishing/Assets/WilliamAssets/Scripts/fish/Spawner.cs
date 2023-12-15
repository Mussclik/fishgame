using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] Vector2 rangeX;
    [SerializeField] Vector2 rangeY;
    [SerializeField] List<GameObject> list;
    bool first = true;

    private void Start()
    {
        rangeX = SortVector(rangeX);
        rangeY = SortVector(rangeY);

        for(int i = 0; i < amount; i++)
        {

            Vector3 newposition = new Vector3(Random.Range(rangeX.x, rangeX.y + 1), Random.Range(rangeY.x, rangeY.y+1),0);
            int rotation = Random.Range(0, 2);
            Vector3 newrotation = Vector3.zero;
            if (rotation == 0)
            {
                newrotation.y = 180;
            }
            Quaternion newerRotation = Quaternion.Euler(newrotation);
            if (first)
            {
                first = false;
                Instantiate(list[0], newposition, Quaternion.identity, transform); 
                amount -= 1;
            }
            Instantiate(list[Random.Range(1, list.Count)], newposition, newerRotation, transform);
        }
    }

    static Vector2 SortVector(Vector2 inputVector)
    {
        float x = Mathf.Min(inputVector.x, inputVector.y);
        float y = Mathf.Max(inputVector.x, inputVector.y);

        return new Vector2(x, y);
    }




}
