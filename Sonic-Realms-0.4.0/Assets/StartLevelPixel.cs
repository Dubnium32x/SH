using UnityEngine;
using SonicRealms.Core.Moves;
using UnityEngine.UI;

public class StartLevelPixel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!Death.IsDead)
            GetComponent<RawImage>().color += Color.white * Time.deltaTime;
        else
            GetComponent<RawImage>().color += Color.black * Time.deltaTime;
    }
}
