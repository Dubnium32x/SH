﻿using System;
using System.IO;
using UnityEngine;
using SonicRealms.Core.Actors;

public class RegularMusic : MonoBehaviour
{
    public AudioSource SecondaryMusic;
    bool StopGo;
    public void Start()
    {
    }
    void Update()
    {
        
        if (SecondaryMusic.isPlaying || HedgehogController.DebugOnS)
        {
            FadeOut(1.6f);
            StopGo = true;
        }
        else
        {
            FadeIn(1.6f, 1);
            StopGo = false;
        }
    }
    void FadeOut(float a)
    {
        if (StopGo == true)
        GetComponent<AudioSource>().volume -= a;
        
    }
    void FadeIn(float a, float whenStop)
    {
        if(GetComponent<AudioSource>().volume <= whenStop && StopGo == false)
            GetComponent<AudioSource>().volume += a;
    }
}
