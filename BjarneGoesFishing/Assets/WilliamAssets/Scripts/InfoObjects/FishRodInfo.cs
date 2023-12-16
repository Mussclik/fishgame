using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FishRodInfo : ItemInfo
{
    int tier;
    [SerializeField] int maxDepth;
    [SerializeField] float reelSpeed;
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
        Debug.Log((int)maxDepth);
        PlayerInfo.maxDepth += maxDepth;
        PersistentManager.maxDepth += maxDepth;
        PlayerInfo.reelSpeedMultiplier += reelSpeed;
        base.Buy();
    }
}
