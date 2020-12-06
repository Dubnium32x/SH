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
        public string ChargeButton;

        /// <summary>
        /// Input that must be released to execute the spindash.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Input that must be released to execute the spindash.")]
        public string ReleaseAxis;


        /// <summary>
        /// An audio clip to play when the spindash is charged.
        /// </summary>
        [SoundFoldout]
        [Tooltip("An audio clip to play when the EarHeli is active.")]
        public AudioClip Helicompter;

        

        

        protected GroundControl GroundControl;

        protected AudioSource ChargeAudioSource;

        public override MoveLayer Layer
        {
            get { return MoveLayer.Action; }
        }

        public override void Reset()
        {
            base.Reset();

            ChargeButton = "Jump";
            ReleaseAxis = "Vertical";


            Helicompter = null;
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            GroundControl = Manager.Get<GroundControl>();

            if (Helicompter == null) return;

            ChargeAudioSource = new GameObject { name = "Charge Audio Source" }.AddComponent<AudioSource>();
            ChargeAudioSource.clip = Helicompter;
            ChargeAudioSource.transform.SetParent(transform);
        }
    }
}