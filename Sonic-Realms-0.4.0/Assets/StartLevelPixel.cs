using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelPixel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool HasSwitched;
    // Update is called once per frame
    void Update()
    {

            GetComponent<RawImage>().color += Color.white * Time.deltaTime;
        
    }
}
