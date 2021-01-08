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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<InputField>().text != SDR.All() && IsModifying.text != "NOT SAVED")
        GetComponent<InputField>().text = SDR.All();

        text = GetComponent<InputField>().text;
        if (Input.GetButtonDown("Submit"))
        {
            SDDM.ModifyAll(text);
            IsModifying.text = "SAVED";
        }
        else if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) || Input.anyKeyDown && !Input.GetMouseButtonDown(1) || Input.anyKeyDown && !Input.GetMouseButtonDown(2))
        {
            IsModifying.text = "NOT SAVED";
        }
    }
}
