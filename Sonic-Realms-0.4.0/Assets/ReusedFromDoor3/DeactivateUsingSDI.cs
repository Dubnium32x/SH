using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
//Made by Birb64, modified from door 3, for use of sonic harmony.
public class DeactivateUsingSDI : MonoBehaviour
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
            gameObject.SetActive(true);
        }
        if (otherThing == value)
        {
            gameObject.SetActive(false);
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
