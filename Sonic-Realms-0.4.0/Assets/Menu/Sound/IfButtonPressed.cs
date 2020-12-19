using UnityEngine;
public class IfButtonPressed : MonoBehaviour{
    public AudioClip MoveSound;
    public AudioClip WrongButton;
    public AudioClip PlayerSound;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetButtonDown("Submit")  && !Input.GetButtonDown("Jump") && !Input.GetButtonDown("Horizontal"))
            { gameObject.GetComponent<AudioSource>().PlayOneShot(WrongButton); }
            else if(Input.GetButtonDown("Submit")) { gameObject.GetComponent<AudioSource>().PlayOneShot(MoveSound); }
            else if(Input.GetButtonDown("Jump")) { gameObject.GetComponent<AudioSource>().PlayOneShot(MoveSound); }
            else if(Input.GetButtonDown("Horizontal")) { gameObject.GetComponent<AudioSource>().PlayOneShot(PlayerSound); }
        }
    }
}
