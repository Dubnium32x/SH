using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtton : MonoBehaviour
{
    public bool IsPaused;
    //Audio
    public AudioSource LevelMusic;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            IsPaused = !IsPaused;
        } 

        if (IsPaused == true)
        {
            //Set the global timer to 0, make sure stuff you wanna have stop, like the player and badniks have their Update() changed to FixedUpdate()
            Time.timeScale = 0f;
            //Make sure level music pauses when paused
            LevelMusic.Pause();
        } else {
          //Set the global timer back to 1 so everything can move again.
          Time.timeScale = 1f;
          //Make sure level music unpauses where it stopped previously
          LevelMusic.UnPause();
        }
    }
}
