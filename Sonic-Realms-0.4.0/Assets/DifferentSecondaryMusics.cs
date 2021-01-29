using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentSecondaryMusics : MonoBehaviour
{
    public AudioClip Invinceble;
    public AudioClip Speedy;
    public static AudioClip Invin;
    public static AudioClip Speed;
    public void Update()
    {
        Speed = Speedy;
            Invin = Invinceble;
    }
}
