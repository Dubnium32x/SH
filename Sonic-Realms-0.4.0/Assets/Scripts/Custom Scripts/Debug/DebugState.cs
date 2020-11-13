using System.Collections;
using System.Collections.Generic;
using SonicRealms.Core.Actors;
using SonicRealms.Level;
using UnityEngine.Events;
using SonicRealms.Core.Moves;
using UnityEngine;


namespace SonicRealms.Core.Actors
{
    public class DebugState : MonoBehaviour
    {



        bool DebugOn = false;
        bool DebugFlyOn;
        public GUIStyle Rainbow;
        public GameObject[] IOFT; /// IOFT stands for Interactable Objects For Testing
        public int AmountOfObjectsInIOFT;
        public int ObjectId;
        public static bool DebugCheck; //Used for other scripts to figure out whether or not debug is on


        //Add the debug mode object here
        public GameObject PlayerObject;

        //Temporary for the sonic transform 
        /// Replace when new mainframe comes out
        public GameObject SonicBOI;

        //Scale and rotation, makes sense, don't it?
        public float ObjectScale;
        public float ObjectRotation;
        bool RandomColorOn;
        GameObject LeObject;
        // Start is called before the first frame update
        void Start()
        {

        }
        int i;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("DebugMode") /* && CheatCodeActivated == true */)
            {
                DebugOn = true;

            }
            DebugCheck = DebugOn;



            //Turns off debug mode entirely
            if (!Input.GetButton("DebugMode") && DebugOn == true)
            {
                //whenever you have the time, add an activated WalkingModeState here
                DebugOn = false;

            }

            //activates on-ground debug mode
            if (DebugOn == true)
            {
                HandleDebugControlFly();
            }

            //activates in-air debug mode

            if (DebugOn == false)
            {

                PlayerObject.SetActive(false);
            }


            PlayerObject.transform.position = SonicBOI.transform.position;
            Debug.Log(DebugOn.ToString());
            Rainbow.normal.textColor = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1));
        }

        public void HandleDebugControlFly()
        {

            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                ObjectId = ObjectId + 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                ObjectId = Mathf.Abs(ObjectId - 1);
            }
            if (Input.GetKey(KeyCode.Keypad1))
            {
                ObjectScale -= 0.1f;
            }
            if (Input.GetKey(KeyCode.Keypad3))
            {
                ObjectScale += 0.1f;
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                ObjectScale = 1;
            }

            if (Input.GetKey(KeyCode.Keypad7))
            {
                ObjectRotation -= 1f;
            }
            if (Input.GetKey(KeyCode.Keypad9))
            {
                ObjectRotation += 1f;
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                ObjectRotation = 0;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                RandomColorOn = true;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                RandomColorOn = false;
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Quaternion StandIn = IOFT[ObjectId].transform.rotation;
                LeObject = Instantiate(IOFT[ObjectId], PlayerObject.transform.position, Quaternion.Euler(StandIn.x, StandIn.y, ObjectRotation));
                LeObject.transform.localScale = new Vector3(ObjectScale, ObjectScale, ObjectScale);
                if (RandomColorOn)
                {
                    LeObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.01f, 1), Random.Range(0.01f, 1), Random.Range(0.01f, 1), 1);
                }
            }


        }


        void DuringGUI()
        {
            if (DebugFlyOn == true)
            {
                GUI.Label(new Rect(500, 50, 1000, 1000), "Simple Dimple Debug System v4.0", Rainbow);
                GUI.Label(new Rect(500, 100, 1000, 1000), "Object Value: " + ObjectId.ToString());
                GUI.Label(new Rect(500, 120, 1000, 1000), "Object Name: " + IOFT[ObjectId].ToString());
                GUI.Label(new Rect(500, 140, 1000, 1000), "Object Scale: " + ObjectScale.ToString());
                GUI.Label(new Rect(500, 160, 1000, 1000), "Object Rotation: " + ObjectRotation.ToString());
                GUI.Label(new Rect(500, 180, 1000, 1000), "Random Color: " + RandomColorOn.ToString());

                GUI.Label(new Rect(500, 220, 100, 1000), "Controls:");
                GUI.Label(new Rect(500, 260, 1000, 1000), "KeypadPeriod: Leave Debug Mode");
                GUI.Label(new Rect(500, 280, 1000, 1000), "Keypad4: scroll through Object Id negative");
                GUI.Label(new Rect(500, 320, 1000, 1000), "Keypad6: scroll through Object Id positive");
                GUI.Label(new Rect(500, 340, 1000, 1000), "Keypad1: Scale down");
                GUI.Label(new Rect(500, 360, 1000, 1000), "Keypad3: Scale up");
                GUI.Label(new Rect(500, 380, 1000, 1000), "Keypad2: Reset Scale");
                GUI.Label(new Rect(500, 420, 1000, 1000), "Keypad7: Rotate Left");
                GUI.Label(new Rect(500, 440, 1000, 1000), "Keypad9: Rotate Right");
                GUI.Label(new Rect(500, 480, 1000, 1000), "Keypad8: Reset Rotation");
                GUI.Label(new Rect(500, 500, 1000, 1000), "Keypad5: Place Object");
                GUI.Label(new Rect(500, 520, 1000, 1000), "TimeScale: " + Time.timeScale.ToString());
            }
            if (DebugOn && !DebugFlyOn)
            {
                GUI.Label(new Rect(500, 50, 1000, 1000), "Simpe Dimple Debug System v4.0", Rainbow);
                GUI.Label(new Rect(500, 100, 1000, 1000), "TimeScale: " + Time.timeScale.ToString());

            }
        }
    }
}
    
