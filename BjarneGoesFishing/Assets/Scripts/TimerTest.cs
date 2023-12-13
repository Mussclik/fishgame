using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class TimerTest
{
    float timer;
    float duration;

    internal TimerTest(float duration)
    {
        this.duration = duration;
    }


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
