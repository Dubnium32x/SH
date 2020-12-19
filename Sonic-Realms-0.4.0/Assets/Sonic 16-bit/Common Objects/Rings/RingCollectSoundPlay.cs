using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCollectSoundPlay : MonoBehaviour
{
    bool IsReadyToDie = false;
    public float pan;
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().panStereo = pan;
            IsReadyToDie = true;
            
        }
        if (IsReadyToDie && !GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
