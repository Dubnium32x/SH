using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOOOOOO : MonoBehaviour
{//-32
    public GameObject TheCancelledOne;
    public AudioSource TheYes;
    public Transform yes;
    
    public void Update()
    {
        if(GameObject.FindWithTag("MainCamera").transform.position.x < -62)
        {
             TheCancelledOne.SetActive(false); if (!TheYes.isPlaying) TheYes.Play(); 
        }
        else
        {
            TheCancelledOne.SetActive(true); TheYes.Stop();
        }
        if (GameObject.FindWithTag("MainCamera").transform.position.x < -65)
        {
            yes.position += Vector3.Lerp(yes.position, Vector3.up * 1.6f * Time.deltaTime, 3.2f);
        }
    }
}
