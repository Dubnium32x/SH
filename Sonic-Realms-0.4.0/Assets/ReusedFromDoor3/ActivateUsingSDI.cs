using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
//made by Birb64, modified from door 3, for use of sonic harmony.
public class ActivateUsingSDI : MonoBehaviour
{
    string otherThing;
    public string CapitalizedPlacement;
    public string value;
    // Start is called before the first frame update
    void Start()
    {
        ASavedValue(CapitalizedPlacement);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(otherThing);
        
        if (otherThing != value)
        {
            gameObject.SetActive(false);
        }
        if (otherThing == value)
        {
            gameObject.SetActive(true);
        }
    }
    public void ASavedValue(string Placement)
    {
        string path = Application.dataPath + "/SDI.H";
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                otherThing = thing;
            }
        }
    }
}
