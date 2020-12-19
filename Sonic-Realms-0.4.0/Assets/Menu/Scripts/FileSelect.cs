using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileSelect : MonoBehaviour
{
    public Vector3[] positionsForFiles;
    [Tooltip("Only include 8 please")]
    public Transform[] Files;
    public int SelectedFile;
    int PreviousFile;
    Vector3 RecScale;
    Vector3 PrevRecScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0.2f)
        {
            SelectedFile += 1;
            PreviousFile = SelectedFile - 1;
            RecScale = Files[SelectedFile].localScale;
            PrevRecScale = Files[PreviousFile].localScale;
        }
        if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < -0.2f)
        {
            SelectedFile -= 1;
            RecScale = Files[SelectedFile].localScale;
            PrevRecScale = Files[PreviousFile].localScale;
            PreviousFile = SelectedFile + 1;
        }
        if(Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SDR.ASV("0Level: "));
        }
        if(SelectedFile < 1) { SelectedFile = 0; }
        if(SelectedFile > 7) { SelectedFile = 8; }
        
    }
}
