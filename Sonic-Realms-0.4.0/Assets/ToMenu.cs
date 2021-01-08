using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public void ToMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
