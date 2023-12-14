using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("----------Music----------")]
    [SerializeField] AudioSource musicSourse;

    [Header("----------AudioClip----------")]
    public AudioClip backGround;

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        musicSourse.clip = backGround;
        musicSourse.Play();
    
    }

}
