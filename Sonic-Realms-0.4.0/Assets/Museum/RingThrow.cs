using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicRealms.Core.Actors;

public class RingThrow : MonoBehaviour
{
    public GameObject Ring;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x < -27.12f && GameObject.FindGameObjectWithTag("Player").transform.position.x > -36.79f && Input.GetKeyDown(KeyCode.A))
        {

            GameObject StandIn = Instantiate(Ring, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            
            StandIn.GetComponent<Collider2D>().enabled = false;

        } }
    }

