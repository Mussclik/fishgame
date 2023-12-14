using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class TimerTest
{
    [SerializeField] private float timer;
    [SerializeField] private float duration;

    internal TimerTest(float duration)
    {
        this.duration = duration;
    }
    #region getset
    public float elapsedTime
    {
        get 
        { 
            return timer; 
        }
    }
    public float Duration
    {
        get 
        {
            return duration;       
        }
    }
    #endregion

    public bool Check()
    {
        if (timer >= duration)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Restart()
    {
        timer = 0;
    }
    public void Start(float duration)
    {
        timer = 0;
        this.duration = duration;
    }
    public void Update()
    {
        timer += Time.deltaTime;
    }
}
