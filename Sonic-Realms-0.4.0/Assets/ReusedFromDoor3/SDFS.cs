using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

//Made by Birb64, modified from door 3, for use of sonic harmony.
/// <summary>
/// SDFS(Simple dimple file setup) is used to setup files that haven't been created yet
/// </summary>
public static class SDFS //What? did you think that I wouldn't find a way to bring door into this? Door is good game, with good code, yes yes.
{
    public static string contents; //A string we will use to make things a bit more simple when making this script

public static string path = Application.dataPath + "/SDI.H"; //the place where we'll make this script

    //public static string path = "Internal storage/Android/data/SDI.H"; //the place where we'll make this script

    public static void CreateFile(int fileID, int Character, int Level, int Lives) //this is where the file is created
    {

         //Application.dataPath just means the place where the assets folder of unity is, and it's a string, not only that, but the "/SDI.H" just makes sure that the path you are sending the "contents" to is in a txt file known as SDI.txt
        contents = "File" + fileID.ToString() + "\n" + fileID.ToString() + "Character: " + Character + "\n" + fileID.ToString() + "Rings: " + "\n" + fileID.ToString() + "Score: " + "\n" + fileID.ToString() + "Lives: " + Lives + "\n" + fileID.ToString() + "Level: " + Level + "\n" + fileID.ToString() + "CheckpointX: " + "\n" + fileID.ToString() + "CheckpointY: " + "\n" + fileID.ToString() + "CheckpointZ: " + "\n" + fileID.ToString() + "ChaosEmeralds: ";
      if (!File.Exists(path)) //if the file exists, duh
        {
            File.WriteAllText(path, contents); //File.WriteAllText basically makes a file where the string "path" takes it, and writes what "contents" has
        }
         if(!SDR.DDVER("File" + fileID.ToString()))
        {
            File.AppendAllText(path, contents);
        }
    }
    }
    

