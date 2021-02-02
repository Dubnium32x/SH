using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicRealms.Core.Actors;
using SonicRealms.Level;

public class SaveManagement : MonoBehaviour
{
    public GameObject Sonic;
    public GameObject Kicks;
    public GameObject Pixelizor;
    public GameObject CurrentCamera;
    GameObject StandInCharac;
    GameObject StandInCharac2;
    public GameObject CurrentObject;
    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("CameraCanvas") != null)
        {
            if (SDR.SDVint(SDR.Character) == 0)
            {
                Sonic.GetComponent<RingCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<LifeCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<ScoreCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                CurrentObject = Sonic;
                if (GameObject.Find("Sonic") == null)
                {
                    StandInCharac = Instantiate(Sonic, new Vector3(
                          SDR.SDVfloat(SDR.CheckpointPosition[0])
                        , SDR.SDVfloat(SDR.CheckpointPosition[1])
                        , SDR.SDVfloat(SDR.CheckpointPosition[2]))
                        , Quaternion.identity);

                }
                
            }
            if (SDR.SDVint(SDR.Character) == 1)
            {
                Sonic.GetComponent<RingCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<LifeCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<ScoreCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                CurrentObject = Kicks;
                if (GameObject.Find("Kicks") == null)
                {
                    StandInCharac = Instantiate(Kicks, new Vector3(
                          SDR.SDVfloat(SDR.CheckpointPosition[0])
                        , SDR.SDVfloat(SDR.CheckpointPosition[1])
                        , SDR.SDVfloat(SDR.CheckpointPosition[2]))
                        , Quaternion.identity);

                }

            }

            if (SDR.SDVint(SDR.Character) == 2)
            {
                Sonic.GetComponent<RingCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<LifeCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                Sonic.GetComponent<ScoreCounter>().CurrentFile = SDR.SDVint(SDR.CurrentFileLoaded);
                CurrentObject = Sonic;
                if (GameObject.Find("Sonic") == null && GameObject.Find("Kicks") == null)
                {
                    StandInCharac = Instantiate(Sonic, new Vector3(
                          SDR.SDVfloat(SDR.CheckpointPosition[0])
                        , SDR.SDVfloat(SDR.CheckpointPosition[1])
                        , SDR.SDVfloat(SDR.CheckpointPosition[2]))
                        , Quaternion.identity);

                    StandInCharac2 = Instantiate(Kicks, new Vector3(
                          SDR.SDVfloat(SDR.CheckpointPosition[0])
                        , SDR.SDVfloat(SDR.CheckpointPosition[1])
                        , SDR.SDVfloat(SDR.CheckpointPosition[2]))
                        , Quaternion.identity);
                }

            }
            
        }
    }
}