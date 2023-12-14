using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFishMenu : MonoBehaviour
{
    [SerializeField] BjarnAnimationScript script;
    public void Exit()
    {
        script.disableButtons = false;
        script.StopCanvas();
        gameObject.SetActive(false);
    }
}
