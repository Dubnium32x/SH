using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{ 
    public SpriteRenderer LeBlack; 
    public Animator PressStartAnim; 
    public AudioSource TitleTheme; 
    bool IsActive; 
    bool HasActivatedSound; 
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Jump") > 0 || Input.GetAxisRaw("Submit") > 0 && !IsActive)
        { 
            PressStartAnim.SetTrigger("Blink"); 
            IsActive = true; 
            if (!HasActivatedSound) 
            { 
                gameObject.GetComponent<AudioSource>().Play(); 
                HasActivatedSound = true;
            } 
        } if (LeBlack.color == Color.black) { SceneManager.LoadScene("Menu"); }
        if (IsActive) 
        { 
            TitleTheme.volume -= 0.2f; LeBlack.color += new Color(0, 0, 0, 0.2f);
        }
    }
}
