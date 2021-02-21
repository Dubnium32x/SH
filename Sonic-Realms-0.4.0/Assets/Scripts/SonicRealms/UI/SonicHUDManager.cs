using SonicRealms.Core.Actors;
using SonicRealms.Level;
using UnityEngine;

namespace SonicRealms.UI
{
    /// <summary>
    /// Updates the Sonic UI with the player's information.
    /// </summary>
    public class SonicHUDManager : MonoBehaviour
    {
        public SonicHUD Hud;

        public void Reset()
        {
            Hud = FindObjectOfType<SonicHUD>();
        }

        public void Start()
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                enabled = false;
                return;
            }

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<RingCounter>() != null) GameObject.FindGameObjectWithTag("Player").GetComponent<RingCounter>().OnValueChange.AddListener(UpdateRings);
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCounter>() != null) GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCounter>().OnValueChange.AddListener(UpdateScore);
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<LifeCounter>() != null) GameObject.FindGameObjectWithTag("Player").GetComponent<LifeCounter>().OnValueChange.AddListener(UpdateLives);

            UpdateAll();
        }

        public void UpdateAll()
        {
            if (Hud == null) return;

            UpdateRings();
            UpdateScore();
            UpdateTimer();
            UpdateLives();
        }

        public void UpdateRings()
        {
            if(Hud != null && Hud.Rings != null)
                Hud.Rings.Show(GameObject.FindGameObjectWithTag("Player").GetComponent<RingCounter>().Rings);
        }

        public void UpdateScore()
        {
            if(Hud != null && Hud.Score != null)
                Hud.Score.Show(GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCounter>().Score);
        }

        public void UpdateTimer()
        {
            if(Hud != null && Hud.Timer != null)
                Hud.Timer.Show(new System.TimeSpan(0,0,(int)Time.timeSinceLevelLoad));
           
        }

        public void UpdateLives()
        {
            if(Hud != null && Hud.LifeCounter != null)
                Hud.LifeCounter.Display(GameObject.FindGameObjectWithTag("Player").GetComponent<LifeCounter>().Lives);
        }
    }
}
