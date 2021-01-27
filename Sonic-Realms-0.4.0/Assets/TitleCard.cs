using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LevelDatabase;

public class TitleCard : MonoBehaviour
{
    public string text;
    public Text texty;
    public bool capped;
    public float SpeedOfAnimationEnter;
    public float SpeedOfAnimationExit;
    void Update()
    {
        if (text == "")
            texty.text = capped ? LevelCaps(SceneManager.GetActiveScene().buildIndex) : Level(SceneManager.GetActiveScene().buildIndex);
        else texty.text = text;
    }
}
