﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoesFileHave : MonoBehaviour
{
    public GameObject SaveManaging;
    public int WhichFile;
    public int Level;
    public int Lives;
    public GameObject CharacterText;
    public GameObject AreYouSure;
    [Tooltip("Currently these are the character ints that will be used throughout SH: 0=S 1=K 2=S&k")]
    public int Character = 0;
    public SpriteRenderer LevelImage;
    public Sprite[] LevelImages;
    public SpriteRenderer CharacterImage;
    public Sprite[] CharacterImages;
    public bool AllowCreateFile;
    public bool CreateFileSettingUp;
    int shouldActivate = 0;
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(SaveManaging);
        
        if (Input.GetButtonDown("Cancel"))
        {
            CharacterText.SetActive(false);
        }
        if (SDR.DDVER(WhichFile.ToString() + "File"))
        {
            if (shouldActivate > 2 || Input.GetButtonDown("Cancel")) { shouldActivate = 0; }
            LevelImage.sprite = LevelImages[SDR.SDVint(WhichFile.ToString() + "Level: " + Level.ToString())];
            CharacterImage.sprite = CharacterImages[SDR.SDVint(WhichFile.ToString() + "Character: " + Character.ToString())];
            if (Input.GetButtonDown("Submit") && shouldActivate == 2 || Input.GetButtonDown("Jump") && shouldActivate == 2)
            {
                if (shouldActivate == 1)
                {
                    AreYouSure.SetActive(true);
                }
                if(shouldActivate == 2)
                {
                    SceneManager.LoadScene(SDR.SDVint("Level: "));
                    SaveManaging.GetComponent<SaveManagement>().CurrentFile = SDR.SDVint("Level: ");
                }
            }
        }
        if (!SDR.DDVER(WhichFile.ToString() + "File"))
        {
            if (Input.GetButtonDown("Submit") && shouldActivate == 2 || Input.GetButtonDown("Jump") && shouldActivate == 2)
            {
                SDFS.CreateFile(WhichFile, Character, Level, Lives);
                SaveManaging.GetComponent<SaveManagement>().CurrentFile = WhichFile;
                SDDM.Modify(WhichFile.ToString() + "ChaosEmeralds: ", "\n" + "CurrentFileLoaded: " + WhichFile.ToString());
                SceneManager.LoadScene(Level);
            }
            
            if (CreateFileSettingUp) 
            { 
                CharacterText.SetActive(true);
                if (Character > 1) { Character = 2; CharacterText.GetComponent<Text>().text = "CHR: SONIC&KICKS"; }

                if (Character < 1) { Character = 0; CharacterText.GetComponent<Text>().text = "CHR: SONIC"; }

                if (Character == 1) { CharacterText.GetComponent<Text>().text = "CHR: KICKS"; }

                if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0.2)
                {
                    Character += 1;
                }
                if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < -0.2)
                {
                    Character -= 1;
                }
            }
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump"))
            {
                CreateFileSettingUp = true;
                
                shouldActivate += 1;
            }
            
        }
    }
}