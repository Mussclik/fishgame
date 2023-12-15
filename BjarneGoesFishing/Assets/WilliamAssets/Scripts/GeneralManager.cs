using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager generalmanager;
    public static AnimationCurve curve;
    public static float curveDuration;
    [SerializeField] private AnimationCurve globalcurve;
    [SerializeField] private float globalCurveDuration;
    internal GeneralManager()
    {
        
    }
    private void Awake()
    {
        generalmanager = this;
        curve = globalcurve;
        curveDuration = globalCurveDuration;
    }
}
