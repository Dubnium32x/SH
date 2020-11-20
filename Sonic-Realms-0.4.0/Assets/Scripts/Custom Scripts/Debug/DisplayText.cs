using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SonicRealms.Core.Actors
{
    public class DisplayText : MonoBehaviour
    {
        void DuringSceneGUI()
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