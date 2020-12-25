using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneThemeBeforeAnother : MonoBehaviour
{
    public AudioClip TheOneBefore;
    public AudioClip TheOneAfter;
    bool StopThisNonsense;
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying && !StopThisNonsense)
        {
            GetComponent<AudioSource>().clip = TheOneBefore;
            GetComponent<AudioSource>().Play();
            StopThisNonsense = true;
        }
        if (!GetComponent<AudioSource>().isPlaying && StopThisNonsense)
        {
            GetComponent<AudioSource>().clip = TheOneAfter;
            GetComponent<AudioSource>().Play();
        }
    }
}
