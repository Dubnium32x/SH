using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class SDDM //Simple dimple data maker modifies the save data when needed
{
    
    public static void Modify(string Placement, string ModifiedValue)
    {
        string path = Application.dataPath + "/SDI.H";
        //string path = Application.persistentDataPath + "/SDI.H";
        string text = File.ReadAllText(path);
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                text = text.Replace(thing, ModifiedValue);
                File.WriteAllText(path, text);
            }
        }
    }
    public static void ModifyAll(string ModifiedValue)
    {
        string path = Application.dataPath + "/SDI.H";
        //string path = Application.persistentDataPath + "/SDI.H";
        string text = File.ReadAllText(path);
        if (File.Exists(path))
        {
            File.WriteAllText(path, ModifiedValue);
        }
    }
    public static void Make(string Placement, string CreatedValue)
    {
        string path = Application.dataPath + "/SDI.H";
        //string path = Application.persistentDataPath + "/SDI.H";
        if (File.Exists(path))
        {
            foreach (string thing in File.ReadAllLines(path).Where(line => line.StartsWith(Placement)))
            {
                File.AppendAllText(path, CreatedValue);
            }
        }
    }
}