using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicRealms.Core.Actors;
using SonicRealms.Level;

public class SaveManagement : MonoBehaviour
{
    public int CurrentFile;
    public GameObject Sonic;
    public GameObject Kicks;
    public GameObject Pixelizor;
    public GameObject CurrentCamera;
    GameObject StandInCharac;
    GameObject StandInCharac2;
    public GameObject CurrentObject;
    public void Start()
    {
        CurrentFile = SDR.SDVint("CurrentFileLoaded: ");
        if (GameObject.FindGameObjectWithTag("CameraCanvas") != null)
        {
            if (SDR.SDVint(CurrentFile.ToString() + "Character: ") == 0)
            {
                Sonic.GetComponent<RingCounter>().CurrentFile = CurrentFile;
                Sonic.GetComponent<LifeCounter>().CurrentFile = CurrentFile;
                Sonic.GetComponent<ScoreCounter>().CurrentFile = CurrentFile;
                CurrentObject = Sonic;
                if (GameObject.Find("Sonic") == null)
                {
                    StandInCharac = Instantiate(Sonic, new Vector3(
                          SDR.SDVfloat(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointX: ")
                        , SDR.SDVfloat(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointY: ")
                        , SDR.SDVfloat(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointZ: "))
                        , Quaternion.identity);

                }
                /*if (GameObject.FindGameObjectWithTag("MainCamera") == null && GameObject.Find("Sonic") != null)
                {
                    GameObject StandInCam = Instantiate(Camera, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);
                    StandInCam.GetComponent<SonicCameraController>().Player = StandInCharac.GetComponent<HedgehogController>();
                    StandInCam.GetComponent<CameraController>().Target = StandInCharac.transform;
                    if (GameObject.FindGameObjectWithTag("CameraCanvas") != null)
                    {
                        GameObject.FindGameObjectWithTag("CameraCanvas").GetComponent<Canvas>().worldCamera = StandInCam.GetComponent<Camera>();
                    }
                }*/
            }
            if (SDR.SDVint(CurrentFile.ToString() + "Character: ") == 1)
            {
                Kicks.GetComponent<RingCounter>().CurrentFile = CurrentFile;
                Kicks.GetComponent<LifeCounter>().CurrentFile = CurrentFile;
                Kicks.GetComponent<ScoreCounter>().CurrentFile = CurrentFile;
                CurrentObject = Kicks;
                if (GameObject.Find("Kicks") == null)
                {
                    StandInCharac = Instantiate(Kicks, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);
                }
                /*if (GameObject.FindGameObjectWithTag("MainCamera") == null && GameObject.Find("Kicks") != null)
                {
                    GameObject StandInCam = Instantiate(Camera, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);
                    StandInCam.GetComponent<SonicCameraController>().Player = StandInCharac.GetComponent<HedgehogController>();
                    StandInCam.GetComponent<CameraController>().Target = StandInCharac.transform;
                    if (GameObject.FindGameObjectWithTag("CameraCanvas") != null)
                    {
                        GameObject.FindGameObjectWithTag("CameraCanvas").GetComponent<Canvas>().worldCamera = StandInCam.GetComponent<Camera>();
                    }
                }*/
            }

            if (SDR.SDVint(CurrentFile.ToString() + "Character: ") == 2)
            {
                Sonic.GetComponent<RingCounter>().CurrentFile = CurrentFile;
                Sonic.GetComponent<LifeCounter>().CurrentFile = CurrentFile;
                Sonic.GetComponent<ScoreCounter>().CurrentFile = CurrentFile;
                CurrentObject = Sonic;
                if (GameObject.Find("Sonic") == null && GameObject.Find("Kicks") == null)
                {
                    StandInCharac = Instantiate(Sonic, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);

                    StandInCharac2 = Instantiate(Kicks, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);
                }
                /*if (GameObject.FindGameObjectWithTag("MainCamera") == null && GameObject.Find("Sonic") != null)
                {
                    GameObject StandInCam = Instantiate(Camera, new Vector3(SDR.SDVfloat("CheckpointX: "), SDR.SDVfloat("CheckpointY: "), SDR.SDVfloat("CheckpointZ: ")), Quaternion.identity);
                    StandInCam.GetComponent<SonicCameraController>().Player = StandInCharac.GetComponent<HedgehogController>();
                    StandInCam.GetComponent<CameraController>().Target = StandInCharac.transform;
                    if (GameObject.FindGameObjectWithTag("CameraCanvas") != null)
                    {
                        GameObject.FindGameObjectWithTag("CameraCanvas").GetComponent<Canvas>().worldCamera = StandInCam.GetComponent<Camera>();
                    }
                }*/
            }
        }
    }
}