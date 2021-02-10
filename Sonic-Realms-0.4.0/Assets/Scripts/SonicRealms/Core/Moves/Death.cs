using SonicRealms.Core.Actors;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SonicRealms.Core.Moves
{
    /// <summary>
    /// Turns off collision and bounces the player off the map.
    /// </summary>
    public class Death : Move
    {

        public static bool IsDead = false;
        /// <summary>
        /// How quickly the controller bounces off the map.
        /// </summary>
        [PhysicsFoldout]
        public float Velocity;

        /// <summary>
        /// How long to wait before ending the move, causing the zone manager to restart the game.
        /// </summary>
        [ControlFoldout]
        public float RestartDelay;

        [HideInInspector]
        public float RestartTimer;

        [HideInInspector]
        public bool Restarting;

        public override void Reset()
        {
            base.Reset();
            Velocity = 4.20f; // blaze it
            RestartDelay = 2.333333f;
        }

        public override void Awake()
        {
            IsDead = false;
            base.Awake();
            RestartTimer = 0.0f;
            Restarting = false;
        }
        public override void Start()
        {
            base.Start();

            IsDead = false;
            Controller.IgnoreCollision = false;
        }
        public override void Update()
        {
            base.Update();
            if (IsDead)
            {
                Controller.transform.position += Vector3.back * 0.05f;
                Controller.transform.rotation = new Quaternion(0, 0, Controller.transform.rotation.z + 24 * Time.deltaTime, Controller.transform.rotation.w + 24 * Time.deltaTime);
            }
        }
        public override void OnActiveEnter(State previousState)
        {
            // Bounce up and ignore collisions
            Controller.Detach();

            // End all moves (except for this one)
            Manager.EndAll(move => move != this);

            Controller.IgnoreCollision = true;
            Controller.RelativeVelocity = new Vector2(0.0f, Velocity);

            // Become invincible to further damage
            var health = Controller.GetComponent<HedgehogHealth>();
            health.Invincible = true;

            // Bring the sprite to the front
            GameObject.FindGameObjectWithTag("SonicSprite").GetComponent<SpriteRenderer>().sortingLayerName = "GUI_HUD_A";
            // Start the death timer
            RestartTimer = RestartDelay;
            Restarting = true;
        }

        public override void OnActiveUpdate()
        {
            if (!Restarting) return;

            
            RestartTimer -= Time.deltaTime;
            if (RestartTimer < 0.0f)
            {
                RestartTimer = 0.0f;
                GameObject.FindGameObjectWithTag("SonicSprite").GetComponent<SpriteRenderer>().sortingLayerName = "Level_Mid_A";
                IsDead = false;
                SceneManager.LoadScene(SDR.SDVint(SDR.Level));
            }
        }
    }
}
