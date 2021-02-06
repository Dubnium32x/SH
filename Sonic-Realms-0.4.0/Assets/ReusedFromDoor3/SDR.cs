using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using static SDR;
//made by Birb64, modified from door3 for use of sonic harmony.
public static class SDR
{

    public static string CurrentFileLoaded = "CurrentFileLoaded: ";
    public static string CheckpointsActivated = SDVint(CurrentFileLoaded).ToString() + "CheckpointsActive: ";
    /// <summary>
    /// 0 is for X axis. 1 is for Y axis. 2 is for Z axis
    /// </summary>
    public static string[] CheckpointPosition = new string[3]
    {
      SDVint(CurrentFileLoaded).ToString() + "CheckpointX: ", SDVint(CurrentFileLoaded).ToString() + "CheckpointY: ", SDVint(CurrentFileLoaded).ToString() + "CheckpointZ: "
    };
    public static string Rings = SDVint(CurrentFileLoaded).ToString() + "Rings: ";
    public static string Lives = SDVint(CurrentFileLoaded).ToString() + "Lives: ";
    public static string Score = SDVint(CurrentFileLoaded).ToString() + "Score: ";
    public static string ChaosEmeralds = SDVint(CurrentFileLoaded).ToString() + "ChaosEmeralds: ";
    public static string Character = SDVint(CurrentFileLoaded).ToString() + "Character: ";
    public static string Level = SDVint(CurrentFileLoaded).ToString() + "Level: ";
    //Save data reader
    // Start is called before the first frame update
    public static string Path = Application.dataPath + "/SDI.H";
    public static string AndroidPath = Application.persistentDataPath + "/SDI.H";

    //save data value int
    public static int SDVint(string Placement, string Remove)
    {
        string path = Application.dataPath + "/SDI.H";
        //string path = Application.persistentDataPath + "/SDI.H";
        int value = 0;
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                value = int.Parse(thing.Replace(Placement, Remove));
                return value;
            }
            return value = 0;
        }
        else
        {
            return value = 0;
        }
    }
    public static int SDVint(string Placement)
    {
        return SDVint(Placement, "");
    }
    
    //save data value float
    public static float SDVfloat(string Placement)
    {
        return SDVfloat(Placement, "");
    }
    public static float SDVfloat(string Placement, string Remove)
    {
        string path = Application.dataPath + "/SDI.H";
        //string path = Application.persistentDataPath + "/SDI.H";
        float value;
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                value = float.Parse(thing.Replace(Placement, Remove));
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
        //string path = Application.persistentDataPath + "/SDI.H";
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
        //string path = Application.persistentDataPath + "/SDI.H"; //I wanted this void to be transportable, so I made this one for scripts without the path
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
    public static string All()
    {
            string path = Application.dataPath + "/SDI.H";
            //string path = Application.persistentDataPath + "/SDI.H";
        return File.ReadAllText(path);
    }
}
