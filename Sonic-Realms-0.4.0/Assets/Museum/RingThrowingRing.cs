using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicRealms.Core.Actors;

public class RingThrowingRing : MonoBehaviour
{
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().FacingForward)
        transform.position += transform.right * 8 * Time.deltaTime;

        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().FacingForward)
            transform.position -= transform.right * 8 * Time.deltaTime;

        if (transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x > 1.6f || transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x < -1.6f)
        Destroy(gameObject);
        
    }
}
