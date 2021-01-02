using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.position = Vector3.Lerp(transform.position, MenuPlaces[5], 0.032f);
            Icons.position = Vector3.Lerp(Icons.position, IconRetirementHome, 0.032f);
        }
        
        
    }
}
