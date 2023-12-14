using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BjarnAnimationScript : MonoBehaviour
{
    [SerializeField] KeyCode key;
    public bool disableButtons = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite sprite;
    [SerializeField] int currentFrameid = -1;
    [SerializeField] List<Sprite> animation;
    TimerTest timer = new TimerTest(0.3f);
    [SerializeField] Card card;
    [SerializeField] GameObject canvas;
    static bool caughtfish = false;
    [SerializeField] bool debug;

    static FishInfo fishinfo;

    private void Start()
    {
        timer.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        if (debug)
        {
            debug = false;
            caughtfish = true;
            fishinfo = ReadInfo.fishList2[3];
        }

        if (caughtfish)
        {
            canvas.SetActive(true);
            card.fishinfo = fishinfo;
            disableButtons = true;
            card.UpdateInfo();
        }

        timer.Update();
        spriteRenderer.sprite = sprite;

        if (Input.GetKeyUp(key) && !disableButtons)
        {
            disableButtons = true;
            timer.enabled = true;
        }
        if(timer.Check())
        {
            currentFrameid++;
            timer.Restart();


        }
        Debug.Log($"{animation.Count} animation");
        Debug.Log($"{currentFrameid} currentFrameID");
        if (currentFrameid >= 0 && currentFrameid <= animation.Count - 1)
        {
            Debug.Log("animatign");
            spriteRenderer.sprite = animation[animation.Count - 1 - currentFrameid];
        }

        if (currentFrameid == animation.Count) 
        {
            SceneManager.LoadScene(1);
            Debug.Log("ChangedScnee");
        }

    }

    public static void GiveInformation(FishInfo fish)
    {
        fishinfo = fish;
        caughtfish = true;
    }
    public void StopCanvas()
    {
        caughtfish = false;
        PlayerInfo.money += fishinfo.value;
    }
}
