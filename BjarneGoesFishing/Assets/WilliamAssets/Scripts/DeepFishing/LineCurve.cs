using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineCurve : MonoBehaviour
{
    [SerializeField] Transform point1, point2, point3;
    [SerializeField] LineRenderer linerenderer;
    [SerializeField, Range(3,50)] float vertexCount;


    private void Start()
    {
        linerenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
    }
    private void Update()
    {

        List<Vector3> pointlist = new List<Vector3>();

        for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
        {
            Vector3 tangent1 = Vector3.Lerp(point1.position, point2.position, ratio);
            Vector3 tangent2 = Vector3.Lerp(point2.position, point3.position, ratio);
            Vector3 curve = Vector3.Lerp(tangent1, tangent2, ratio);
            pointlist.Add(curve);
        }
        linerenderer.positionCount = pointlist.Count;
        linerenderer.SetPositions(pointlist.ToArray());
    }
}
