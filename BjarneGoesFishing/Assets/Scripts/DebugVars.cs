using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class DebugVars
{
    [SerializeField] public List<int> ints = new List<int>();
    [SerializeField] public List<bool> bools = new List<bool>();
    [SerializeField] public List<string> strings = new List<string>();
    [SerializeField] public List<Vector3> vector3s = new List<Vector3>();
    [SerializeField] public List<TimerTest> timers = new List<TimerTest>();

    public void AddToAll(int amount)
    {
        for (int i = 0; i < amount; i++) 
        {
            ints.Add(0);
            bools.Add(false);
            strings.Add("");
            vector3s.Add(Vector3.zero);
            timers.Add(new TimerTest(0));
        }

    }
}
