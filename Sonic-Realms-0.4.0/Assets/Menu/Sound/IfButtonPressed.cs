using UnityEngine;
public class IfButtonPressed : MonoBehaviour{
    public AudioClip MoveSound;
    public AudioClip WrongButton;
    public AudioClip PlayerSound;
    public AudioClip Meg1;
    public AudioClip Meg2;
    public AudioClip Meg3;
    public AudioClip Meg4;
    public AudioClip Meg5;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetButtonDown("Submit")  && !Input.GetButtonDown("Jump") && !Input.GetButtonDown("Horizontal") && !Input.GetKeyDown(KeyCode.B) && !Input.GetKeyDown(KeyCode.I) && !Input.GetKeyDown(KeyCode.R) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.E))
            { gameObject.GetComponent<AudioSource>().PlayOneShot(WrongButton); }
            else if(Input.GetButtonDown("Submit")) { gameObject.GetComponent<AudioSource>().PlayOneShot(MoveSound); }
            else if(Input.GetButtonDown("Jump")) { gameObject.GetComponent<AudioSource>().PlayOneShot(MoveSound); }
            else if(Input.GetButtonDown("Horizontal")) { gameObject.GetComponent<AudioSource>().PlayOneShot(PlayerSound); }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(Meg1);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(Meg2);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(Meg3);

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(Meg4);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(Meg5);
            }
        }
    }
}
