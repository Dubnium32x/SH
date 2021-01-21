using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicRealms.Core.Actors;

public class SDDSounds : MonoBehaviour
{
    public AudioClip[] Sounds;
    public int SizeOfArray;
    void Update()
    {
        if (Input.GetButtonDown("DebugKey") && HedgehogController.DebugOnS)
            GetComponent<AudioSource>().PlayOneShot(Sounds[Random.Range(0, SizeOfArray)]);

        if (GetComponent<AudioSource>().isPlaying && GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().isPlaying)
            GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 0.32f;
        else GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 1f;

        if (GetComponent<AudioSource>().isPlaying && GameObject.FindGameObjectWithTag("MusicPlayer2").GetComponent<AudioSource>().isPlaying)
            GameObject.FindGameObjectWithTag("MusicPlayer2").GetComponent<AudioSource>().volume = 0.32f;
        else GameObject.FindGameObjectWithTag("MusicPlayer2").GetComponent<AudioSource>().volume = 1f;
    }
}
