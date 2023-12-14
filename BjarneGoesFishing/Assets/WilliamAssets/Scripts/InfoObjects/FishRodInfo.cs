using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FishRodInfo : ItemInfo
{
    int tier;
    float maxDepth;
    internal FishRodInfo()
    {
        consumable = false;
    }
    public override void GetidInfo(int id)
    {
        
        base.GetidInfo(id);
    }
    public override void Buy()
    {
        PlayerInfo.maxDepth += (int)maxDepth;


        base.Buy();
    }
}
