using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
//made by Birb64, modified from door3 for use of sonic harmony.
public static class SDR
{
    //Save data reader
    // Start is called before the first frame update
    public static string Path = Application.dataPath + "/SDI.H";

    //save data value int
    public static int SDVint(string Placement)
    {
        string path = Application.dataPath + "/SDI.H";
        int value = 0;
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                value = int.Parse(thing.Replace(Placement, ""));
                return value;
            }
            return value = 0;
        }
        else
        {
            return value = 0;
        }
    }

    //save data value float
    public static float SDVfloat(string Placement)
    {
        string path = Application.dataPath + "/SDI.H";
        float value = 0;
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                value = int.Parse(thing.Replace(Placement, ""));
                return value;
            }
            return value = 0;
        }
        else
        {
            return value = 0;
        }
    }
    //Does data value exist raw
    public static bool DDVER(string Placement)
    {
        string path = Application.dataPath + "/SDI.H";
        bool Exists = false;
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                if (thing == Placement)
                {
                    Exists = true;
                }
                if(thing != Placement)
                {
                    Exists = false;
                }
            }
            return Exists;
        }
        else
        {
            return false;
        }
        
    }
    //Checks for a saved value
    public static string ASV(string Placement)
    {
        string path = Application.dataPath + "/SDI.H"; //I wanted this void to be transportable, so I made this one for scripts without the path
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement))) //finds the column
            {
                return thing.Replace(Placement, "");
            }
            return "";
        }
        else
        {
            return "";
        }
    }
    public static string All
    {
        get { string path = Application.dataPath + "/SDI.H"; return File.ReadAllText(path);}
        set { string path = Application.dataPath + "/SDI.H";}
        
    }

}
