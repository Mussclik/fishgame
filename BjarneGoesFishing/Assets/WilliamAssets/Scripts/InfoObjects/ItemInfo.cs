using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInfo : Info
{
    public bool consumable;
    public int price;

    public virtual void Enable()
    {

    }
    public virtual void Disable()
    {

    }
    public virtual void Buy()
    {
        PlayerInfo.money -= price;
    }
}
