using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class FishRodInfo : ItemInfo
{
    int tier;
    float maxDepth;
    float maxRange;
    internal FishRodInfo()
    {
        consumable = false;
    }
    public override void GetidInfo(int id)
    {
        
        base.GetidInfo(id);
    }
}