using UnityEngine;
//made by Birb64, modified from door 3, for use of sonic harmony.
public class ActivateUsingSDI : MonoBehaviour
{
    public string Word;

    void Update()
    {
            gameObject.SetActive(SDR.DDVER(Word));
    }
}
