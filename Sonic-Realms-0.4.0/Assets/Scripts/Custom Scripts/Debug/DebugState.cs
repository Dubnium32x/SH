using System.Collections;
using System.Collections.Generic;
using SonicRealms.Core.Actors;
using SonicRealms.Level;
using UnityEngine.Events;
using SonicRealms.Core.Moves;
using UnityEngine;
using UnityEngine.UI;


namespace SonicRealms.Core.Actors
{
    public class DebugState : MonoBehaviour
    {
        public static DebugState Instance;
        public static GameObject PlayerObjectS;

        public Texture2D textureToDisplay;
            public static Texture2D textureToDisplayS;
        bool DebugOn = false;
        
        bool DebugFlyOn;
        public GUIStyle Rainbow;
        public AudioClip RegularMusic;
        public AudioClip RegularMusicS;
        

        public Text ScoreModifier;
        public Text RingsModifier;
        public Text LivesModifier;
        public Text TimeModifier;
        public static Text ScoreModifierS;
        public static Text RingsModifierS;
        public static Text LivesModifierS;
        public static Text TimeModifierS;


        public GameObject[] IOFT; /// IOFT stands for Interactable Objects For Testing
        public static GameObject[] IOFTS; ///the static version for the new debug mode
        public int AmountOfObjectsInIOFT;
        public static int AmountOfObjectsInIOFTS;
        public int ObjectId;


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


            RegularMusicS = RegularMusic;
            AmountOfObjectsInIOFTS = AmountOfObjectsInIOFT;
            if (Input.GetButton("DebugMode") /* && CheatCodeActivated == true */)
            {
                DebugOn = true;

            }
            textureToDisplayS = textureToDisplay;
            IOFTS = IOFT;
            PlayerObjectS = PlayerObject;

            //Turns off debug mode entirely
            if (!Input.GetButton("DebugMode") && DebugOn == true)
            {
                //whenever you have the time, add an activated WalkingModeState here
                DebugOn = false;

            }
            LivesModifierS = LivesModifier;
            ScoreModifierS = ScoreModifier;
            TimeModifierS = TimeModifier;
            RingsModifierS = RingsModifier;
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


        
    }

    
}
namespace SonicRealms.UI
{
    public class DebugUI : MonoBehaviour
    {
        void DuringGUI()
        {
            if (HedgehogController.DebugOnS == true)
            {
                GUI.Label(new Rect(500, 50, 1000, 1000), "Simple Dimple Debug System v4.0");
                GUI.Label(new Rect(500, 100, 1000, 1000), "Object Value: " + HedgehogController.ObjectIdS.ToString());
                GUI.Label(new Rect(500, 120, 1000, 1000), "Object Name: " + DebugState.IOFTS[HedgehogController.ObjectIdS].ToString());
                GUI.Label(new Rect(500, 140, 1000, 1000), "Object Scale: " + HedgehogController.ObjectScaleS.ToString());
                GUI.Label(new Rect(500, 160, 1000, 1000), "Object Rotation: " + HedgehogController.ObjectRotationS.ToString());

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
            
        }
    }
}