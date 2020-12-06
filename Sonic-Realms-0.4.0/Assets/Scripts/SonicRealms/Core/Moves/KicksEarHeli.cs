using UnityEngine;

namespace SonicRealms.Core.Moves
{
    public class KicksEarHeli : Move
    {        
        /// <summary>
        /// Input for charging.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Input for charging.")]
        public KeyCode ChargeButton;



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



            Helicompter = null;
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
           

            if (Helicompter == null) return;

            ChargeAudioSource = new GameObject { name = "Charge Audio Source" }.AddComponent<AudioSource>();
            ChargeAudioSource.clip = Helicompter;
            ChargeAudioSource.transform.SetParent(transform);
        }

        public override bool Available
        {
            get { return base.Available; }
        }
        bool active;
        public override void OnActiveEnter()
        {
            base.OnActiveEnter();

            active = true;
            if (ChargeAudioSource == null) return;
            ChargeAudioSource.Play();
        }

        public override void OnActiveUpdate()
        {
            Controller.Animator.SetBool("Helicomptering", true);
            base.OnActiveUpdate();
            if (Input.GetKey(ChargeButton) && active == true)
            {
                Controller.RelativeVelocity = new Vector2(Controller.RelativeVelocity.x, 1);
                
            }
            else
            {
                active = false;
                End();
            }

        }
        public override void OnActiveExit()
        {
            base.OnActiveExit();
            Controller.Animator.SetBool("Helicomptering", false);


        }
    }
}