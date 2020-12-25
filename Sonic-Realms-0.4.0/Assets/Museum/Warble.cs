using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warble : MonoBehaviour
{
    float warble = 0.032f;
    // Update is called once per frame
    void Update()
    {
        warble += 0.032f;
        if (warble > 0.64f)
        { warble = 0.63f; }

        GetComponent<AudioSource>().pitch = warble;
    }
}
