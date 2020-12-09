using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        [SoundFoldout]
        [Tooltip("An audio clip to play when the EarHeli is active.")]
        public AudioClip Helicompter;





        protected AudioSource ChargeAudioSource;


        public override void Reset()
        {
            base.Reset();
            A = true;


            Helicompter = null;
        }

        public override void Awake()
        {
            base.Awake();
            
        }
        int i;
        public override void Start()
        {
            base.Start();
           

            if (Helicompter == null) return;

            ChargeAudioSource = new GameObject { name = "Charge Audio Source" }.AddComponent<AudioSource>();
            ChargeAudioSource.clip = Helicompter;
            ChargeAudioSource.transform.SetParent(transform);
        }
        bool A;
        public override void OnActiveEnter()
        {
            base.OnActiveEnter();
            A = true;
        }

        public override bool Available
        {
            get { return Input.GetButtonDown(HeliButton); }
        }

        public override bool ShouldPerform
        {
            get { return !Controller.Grounded; }
        }
        public override void OnActiveUpdate()
        {
            base.OnActiveUpdate();
            if (Input.GetButton(HeliButton) && A == true && Controller.RelativeVelocity.y < 0 && !Controller.Grounded)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (ChargeAudioSource.clip != Helicompter && !ChargeAudioSource.isPlaying) return;
                {
                    ChargeAudioSource.Play();
                }
            }
            
            if (Input.GetButtonUp(HeliButton) || Controller.Grounded)
            {
                A = false;
                Controller.Animator.SetBool("Helicomptering", false);

                End();
                ChargeAudioSource.Stop();
            }
        }
    }
}