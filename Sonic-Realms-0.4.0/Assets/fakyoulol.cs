using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakyoulol : MonoBehaviour
{
    public Sprite Fakked;
    public float BoxSize;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x - BoxSize && GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x + BoxSize && GameObject.FindGameObjectWithTag("Player").transform.position.y < transform.position.y + BoxSize && GameObject.FindGameObjectWithTag("Player").transform.position.y > transform.position.y - BoxSize && GetComponent<SpriteRenderer>().sprite != Fakked)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = Fakked;
        }
    }
}
