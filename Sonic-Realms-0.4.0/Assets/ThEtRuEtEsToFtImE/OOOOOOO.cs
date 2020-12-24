using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOOOOOO : MonoBehaviour
{//-32
    public GameObject TheCancelledOne;
    public AudioSource TheYes;
    
    
    public void Update()
    {
        if(GameObject.FindWithTag("MainCamera").transform.position.x < -32)
        {
             TheCancelledOne.SetActive(false); if (!TheYes.isPlaying) TheYes.Play(); 
        }
        else
        {
            TheCancelledOne.SetActive(true); TheYes.Stop();
        }
    }
}
