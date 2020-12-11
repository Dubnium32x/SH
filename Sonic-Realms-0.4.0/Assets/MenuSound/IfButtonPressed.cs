using UnityEngine;
public class IfButtonPressed : MonoBehaviour{
    public AudioClip MoveSound;
    public AudioClip WrongButton;
    public AudioClip PlayerSound;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetButtonDown("Vertical") && !Input.GetButtonDown("Horizontal"))
            { gameObject.GetComponent<AudioSource>().PlayOneShot(WrongButton); }
            else if(Input.GetButtonDown("Vertical")) { gameObject.GetComponent<AudioSource>().PlayOneShot(MoveSound); }
            else if(Input.GetButtonDown("Horizontal")) { gameObject.GetComponent<AudioSource>().PlayOneShot(PlayerSound); }
        }
    }
}
