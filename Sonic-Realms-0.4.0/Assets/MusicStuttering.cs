using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStuttering : MonoBehaviour
{
    public float HowFar;
    public float Velocity;
    float pitch;
    public void Start()
    {
        pitch = GetComponent<AudioSource>().pitch;
    }
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<AudioSource>().pitch < HowFar)
        {
            GetComponent<AudioSource>().pitch += Velocity * Time.deltaTime;
        }
        else
        {
            GetComponent<AudioSource>().pitch = pitch;
        }

    }
}
