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
        public List<KeyCode> HeliButton = new List<KeyCode>();

        ///<summary>
        ///Since unity is such a bitch when it comes to List.Length I made it easier on me and made you type in how many buttons there are. I know, shocking.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Since unity is such a bitch when it comes to List.Length I made it easier on me and made you type in how many buttons there are. I know, shocking.")]
        public int amountOfKeysUsed;

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
            HeliButton.Add(HeliButton[0]);
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
            get { return base.Available; }
        }

        public override bool ShouldPerform
        {
            get { return !Controller.Grounded; }
        }
        public override void Update()
        {


            if (i < amountOfKeysUsed)
            {
                i++;
                HeliButton.Add(HeliButton[i]); //if people knew this was from door 3, they'd be terrified of what comes next in 2022
            }
        }
        public override void OnActiveUpdate()
        {
            base.OnActiveUpdate();
            #region it may look like shit, but I tell ya, if you're not watching the super mario brothers super show, you're gonna turn into a goomba
            if (Input.GetKey(HeliButton[0]) && A == true && Controller.RelativeVelocity.y < 0 && !Controller.Grounded)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (ChargeAudioSource.clip != Helicompter && !ChargeAudioSource.isPlaying) return;
                {
                    ChargeAudioSource.Play();
                }
            }
            if (Input.GetKey(HeliButton[1]) && A == true && Controller.RelativeVelocity.y < 0 && !Controller.Grounded)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (ChargeAudioSource.clip != Helicompter && !ChargeAudioSource.isPlaying) return;
                {
                    ChargeAudioSource.Play();
                }
            }
            if (Input.GetKey(HeliButton[2]) && A == true && Controller.RelativeVelocity.y < 0 && !Controller.Grounded)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (ChargeAudioSource.clip != Helicompter && !ChargeAudioSource.isPlaying) return;
                {
                    ChargeAudioSource.Play();
                }
            }
            if (Input.GetKey(HeliButton[3]) && A == true && Controller.RelativeVelocity.y < 0 && !Controller.Grounded)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, floatingAmount);
                Controller.Animator.SetBool("Helicomptering", true);

                if (ChargeAudioSource.clip != Helicompter && !ChargeAudioSource.isPlaying) return;
                {
                    ChargeAudioSource.Play();
                }
            }
            #endregion
            if (Input.GetKeyUp(HeliButton[0]) || Input.GetKeyUp(HeliButton[1]) || Input.GetKeyUp(HeliButton[2]) || Input.GetKeyUp(HeliButton[3]) || Controller.Grounded)
            {
                A = false;
                Controller.Animator.SetBool("Helicomptering", false);

                End();
                ChargeAudioSource.Stop();
            }
        }
    }
}