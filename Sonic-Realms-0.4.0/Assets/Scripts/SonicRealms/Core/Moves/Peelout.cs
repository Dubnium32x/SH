using UnityEngine;

namespace SonicRealms.Core.Moves
{
    public class Peelout : Move
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


        ///<summary>
        /// How fast you want the peelout to charge.
        /// </summary>
        [ControlFoldout]
        [Tooltip("How fast you want the peelout to charge.")]
        public float FastsPerUnit;

        /// <summary>
        /// Fast cap for peelout(a charge cap)
        /// </summary>
        [ControlFoldout]
        [Tooltip("Fast cap for peelout(a charge cap)")]
        public float FastsCap;

        /// <summary>
        /// An audio clip to play when the spindash is charged.
        /// </summary>
        [SoundFoldout]
        [Tooltip("An audio clip to play when the spindash is charged.")]
        public AudioClip ChargeSound;

        /// <summary>
        /// Peelout Charge float(tells how fast sonic is going to the animator)
        /// </summary>
        [AnimationFoldout]
        [Tooltip("Peelout Charge float(tells how fast sonic is going to the animator)")]
        public string PeeloutCharge;

        /// <summary>
        /// Changes how fast the animator animates the peelout
        /// </summary>
        [AnimationFoldout]
        [Tooltip("Changes how fast the animator animates the peelout")]
        public string PeeloutFasts;

        protected GroundControl GroundControl;
        
        protected AudioSource ChargeAudioSource;

        float CurrentCharge;


        float CurrentCharge2;

        float CurrentChargeOut;

        public override MoveLayer Layer
        {
            get { return MoveLayer.Action; }
        }

        public override void Reset()
        {
            base.Reset();

            ChargeButton = "Jump";
            ReleaseAxis = "Vertical";


            ChargeSound = null;
        }

        public override void Awake()
        {
            base.Awake();
            CurrentCharge = 0f;
            CurrentCharge2 = 0f;
            CurrentChargeOut = 0f;
        }

        public override void Start()
        {
            base.Start();
            
            GroundControl = Manager.Get<GroundControl>();

            if (ChargeSound == null) return;

            ChargeAudioSource = new GameObject {name = "Charge Audio Source"}.AddComponent<AudioSource>();
            ChargeAudioSource.clip = ChargeSound;
            ChargeAudioSource.transform.SetParent(transform);
        }
        

        public override bool Available
        {
            get { return Manager[MoveLayer.Action] is LookUp; }
        }

        public override bool ShouldPerform
        {
            get { return Input.GetButtonDown(ChargeButton); }
        }

        public override void OnActiveEnter(State previousState)
        {
            CurrentCharge = 0.0f;
            CurrentCharge2 = 0.0f;

            CurrentChargeOut = 0f;
            if (GroundControl != null)
                GroundControl.DisableControl = true;

            if (ChargeAudioSource == null) return;
            ChargeAudioSource.Play();
        }
  

        public override void OnActiveUpdate()
        {
            float ChargeForAnimator = CurrentCharge2 * 1.2f;
            Controller.Animator.SetFloat(PeeloutCharge, CurrentCharge);
            Controller.Animator.SetFloat(PeeloutFasts, ChargeForAnimator);
                CurrentCharge -= CurrentCharge * Time.deltaTime;
                CurrentCharge2 += (CurrentCharge2 / 2) * Time.deltaTime;

            if (Input.GetButton(ChargeButton))
                Charge();
            

            if (CurrentCharge > FastsCap) CurrentCharge = FastsCap;
            if (CurrentCharge2 > FastsCap) CurrentCharge2 = FastsCap * 2;

            if (CurrentChargeOut > FastsCap) CurrentChargeOut = FastsCap;

            if (Input.GetButtonUp(ChargeButton))
                Finish();
        }

        public override void OnActiveExit()
        {
            if (GroundControl != null)
                GroundControl.DisableControl = false;

            if (ChargeAudioSource != null)
                ChargeAudioSource.Stop();
        }

        public void Charge()
        {
           
                CurrentCharge += FastsPerUnit * Time.deltaTime;
                CurrentCharge2 += FastsPerUnit * Time.deltaTime;
            if(CurrentCharge > 5 && CurrentChargeOut < FastsCap)
            {
                CurrentChargeOut += FastsPerUnit * Time.deltaTime;
            }
            
        }

        public void Finish()
        {
                if (Controller.FacingForward)
                    Controller.GroundVelocity = CurrentChargeOut;
                else
                    Controller.GroundVelocity = -CurrentChargeOut;
            
            
            End();
        }
    }
}
