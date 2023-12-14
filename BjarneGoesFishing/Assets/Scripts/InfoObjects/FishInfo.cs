using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FishInfo : Info
{
    //:info
    //name
    //description

    public int value;
    public int tier;
    public int minDepth; 
    public int maxDepth;
    public float phugoidRange; // how much fish go up down up down when swim
    public float baitRange;
    public float speed;
}
