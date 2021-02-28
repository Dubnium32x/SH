using UnityEngine;
using SonicRealms.Core.Actors;

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
                          SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[0]) : transform.position.x
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[1]) : transform.position.y
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[2]) : transform.position.z)
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
                          SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[0]) : transform.position.x
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[1]) : transform.position.y
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[2]) : transform.position.z)
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
                          SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[0]) : transform.position.x
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[1]) : transform.position.y
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[2]) : transform.position.z)
                        , Quaternion.identity);

                    StandInCharac2 = Instantiate(Kicks, new Vector3(
                          SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[0]) : transform.position.x
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[1]) : transform.position.y
                        , SDR.SDVint(SDR.CheckpointsActivated) != 0 ? SDR.SDVfloat(SDR.CheckpointPosition[2]) : transform.position.z)
                        , Quaternion.identity);
                }

            }
            
        }
    }
}