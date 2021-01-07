using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifySDIScreen : MonoBehaviour
{
    string text;
    public Text IsModifying;
    void Start()
    {
        GetComponent<InputField>().text = SDR.All;
    }

    // Update is called once per frame
    void Update()
    {
         text = GetComponent<InputField>().text;
        if (Input.GetButtonDown("Submit"))
        {
            SDDM.ModifyAll(text);
            IsModifying.text = "SAVED";
        }
        else if (Input.anyKeyDown)
        {
            IsModifying.text = "NOT SAVED";
        }
    }
}
