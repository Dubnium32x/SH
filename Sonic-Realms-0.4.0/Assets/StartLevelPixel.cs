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
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (!Death.IsDead && timer >= 2)
            GetComponent<RawImage>().color += Color.white * Time.deltaTime;
        else
        {
            GetComponent<RawImage>().color += Color.black * (Color.clear / 2) * Time.deltaTime;
        }
    }
}
