using UnityEngine;
using UnityEngine.UI;
using SonicRealms.Core.Actors;

public class Teleport : MonoBehaviour
{
    public Text[] TextX = new Text[0];
    public Text[] TextY = new Text[0];
    public Text[] TextZ = new Text[0];
    public Text XYZ;
    private bool IsPressed;

    public void Pressed()
    {
        IsPressed = true;
    }

    void Update()
    {

        #region XYZ changer
        XYZ.text = "X: " + GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.x.ToString() + "\nY: " + GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.y.ToString() + "\nZ: " + GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.z.ToString();
        #endregion
        float X = float.Parse(TextX[0].text) != 0 ? float.Parse(TextX[0].text): 0;
        float Y = float.Parse(TextY[0].text) != 0 ? float.Parse(TextY[0].text): 0;
        float Z = float.Parse(TextZ[0].text) != 0 ? float.Parse(TextZ[0].text): 0;
        if (!GameObject.Find("RelativeToggle").GetComponent<Toggle>().isOn)
        {
            #region Simplicities
            if (X == 0 && Z == 0 && Y != 0)
            {
                Y = GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.y;
            }
            if (Y == 0 && Z == 0 && X != 0)
            {
                X = GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.y;
            }
            if (X == 0 && Y == 0 && Z != 0)
            {
                Z = GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.y;
            }
            #endregion}
        }
        if (IsPressed)
        {
            if(!GameObject.Find("RelativeToggle").GetComponent<Toggle>().isOn)
            GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position = new Vector3(X, Y, Z);
            else
                GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.x + X, GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.y + Y, GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().transform.position.z + Z);
            IsPressed = false;

        }
    }
}
