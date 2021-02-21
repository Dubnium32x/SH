
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCursor : MonoBehaviour
{
    public int Placement;
    public int MaxPlacements;
    public Vector3[] MenuPlaces;
    [Tooltip("ye, I'm the funniest fuck there is")]
    public Vector3 IconRetirementHome;
    public Transform Icons;
    bool IsActive;
    public GameObject FileSelect;
    bool PlacementMoving;
    bool B;
    bool I;
    bool R;
    bool D;
    public void Start()
    {
        SDDM.Modify(SDR.CheckpointsActivated, SDR.CheckpointsActivated + "0");
        SDDM.Modify(SDR.CheckpointPosition[0], SDR.CheckpointPosition[0] + "0");
        SDDM.Modify(SDR.CheckpointPosition[1], SDR.CheckpointPosition[1] + "0");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0 && !IsActive && Placement < 4 && PlacementMoving)
        {
            Placement += 1;
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && !IsActive && PlacementMoving)
        {
            Placement -= 1;
        }
        PlacementMoving = Input.GetAxisRaw("Horizontal") != 0 ? false : true;

        if (Placement > 3 && !IsActive) { Placement = 4; }
        if(Placement < 0) { Placement = 0; }
        if (!IsActive)
        {
            transform.position = Vector3.Lerp(transform.position, MenuPlaces[Placement], 0.032f);
            Icons.position = Vector3.Lerp(Icons.position, Vector3.zero, 0.032f);
        }
        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump"))
        {
            IsActive = true;
            if(Placement == 0)
            {
                FileSelect.SetActive(true);
            }

            if (Placement == 4)
            {
                Application.Quit();
            }
                
            
        }
        if (Input.GetButtonDown("Cancel"))
        {
            IsActive = false;
            if (Placement == 0)
            {
                FileSelect.SetActive(false);
            }
        }
        if(IsActive)
        {
            transform.position = Vector3.Lerp(transform.position, MenuPlaces[5] , 0.032f);
            Icons.position = Vector3.Lerp(Icons.position, IconRetirementHome, 0.032f);
        }
        
        if (Input.GetKey(KeyCode.B))
        {
            B = true;
            if (Input.GetKey(KeyCode.I)&&B)
            {
                I = true;
                if (Input.GetKey(KeyCode.R)&&I)
                {
                    R = true;
                    if (Input.GetKey(KeyCode.D)&&R)
                    {
                        D = true;
                        if (Input.GetKey(KeyCode.E)&&D) 
                        {

                                SceneManager.LoadScene("SDModify");
                            
                        }
                    }
                    else if(Input.anyKey && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.E)) { D = false; }
                }
                else if(Input.anyKey && !Input.GetKey(KeyCode.R) && !Input.GetKey(KeyCode.D)) { R = false; }
            }
            else if (Input.anyKey && !Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.R)) { I = false; }
        }
        else if (Input.anyKey && !Input.GetKey(KeyCode.B) && !Input.GetKey(KeyCode.I)) { B = false; }
    }
}
