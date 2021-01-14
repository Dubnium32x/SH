using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDDSounds : MonoBehaviour
{
    public AudioClip[] Sounds;
    public int SizeOfArray;
    void Update()
    {
        if(Input.GetButtonDown("DebugKey"))
        GetComponent<AudioSource>().PlayOneShot(Sounds[Random.Range(0, SizeOfArray)]);
    }
}
