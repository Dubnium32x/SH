using UnityEngine;
using SonicRealms.Core.Actors;
namespace SonicRealms.Core.Moves
{
    public class KicksEarHeli : Move
    {        
        /// <summary>
        /// Input for EarHeli'ing.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Input for EarHeli'ing.")]
        public string HeliButton;


        /// <summary>
        /// Something about the floating of the EarHeli idk.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Something about the floating of the EarHeli idk.")]
        public float floatingAmount;

        /// <summary>
        /// An audio clip to play when the spindash is charged.
        /// </summary>
        [ControlFoldout]
        [Tooltip("An audio clip to play when the EarHeli is active.")]
        public AudioClip Helicompter;

        /// <summary>
        /// An audio clip to play when the spindash is charged.
        /// </summary>
        [ControlFoldout]
        [Tooltip("An audio clip to play when the EarHeli is active.")]
        public AudioSource HelicompterSource;



        public override void Reset()
        {
            base.Reset();
            A = true;
        }

        public override void Start()
        {
            base.Start();
           

            if (Helicompter == null) return;

            HelicompterSource.clip = Helicompter;
        }
        bool A;
        public override void OnActiveEnter()
        {
            base.OnActiveEnter();
            A = true;
        }


        public override bool Available
        {
            get { return base.Available; }
        }

        public override bool ShouldPerform
        {
            get { return Input.GetButton(HeliButton) && !HedgehogController.DebugOnS; }
        }
        public override void Update()
        {
            if (Input.GetButton(HeliButton) && A == true && GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().RelativeVelocity.y < 0 && !GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().Grounded)
            {
                Controller.RelativeVelocity = new Vector2(GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (HelicompterSource.clip != Helicompter && !HelicompterSource.isPlaying) return;
                {
                    HelicompterSource.Play();
                    HelicompterSource.clip = Helicompter;
                }
            }
            
            if (Input.GetButtonUp(HeliButton) || Controller.Grounded)
            {
                A = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<HedgehogController>().Animator.SetBool("Helicomptering", false);

                HelicompterSource.Stop();
                End();
            }
        }
        public override void OnActiveExit()
        {
            base.OnActiveExit();
            A = false;
        }
    }
}