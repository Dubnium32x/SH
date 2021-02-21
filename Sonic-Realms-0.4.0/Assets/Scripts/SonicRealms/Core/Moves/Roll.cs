using SonicRealms.Core.Actors;
using SonicRealms.Core.Utils;
using UnityEngine;

namespace SonicRealms.Core.Moves
{
    /// <summary>
    /// Traditional Sonic rolling. Makes you not as slow going uphill and even faster going downhill.
    /// </summary>
    public class Roll : Move
    {
        public static bool IsRolling;
        #region Controls
        /// <summary>
        /// Input string used for activation.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Input string used for activation.")]
        public string ActivateAxis;

        /// <summary>
        /// Whether to activate when the input is in the opposite direction (if ActivateButton is "Vertical" and this
        /// is true, activates when input moves down instead of up).
        /// </summary>
        [ControlFoldout]
        [Tooltip("Whether to activate when the input is in the opposite direction (if ActivateButton is \"Vertical\" " +
                 "and this is true, activates when input moves down instead of up.")]
        public bool RequireNegative;

        /// <summary>
        /// Minimum ground speed required to start rolling, in units per second.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Minimum ground speed required to start rolling, in units per second.")]
        public float MinActivateSpeed;
        #endregion
        #region Physics
        /// <summary>
        /// This hitbox becomes harmful while rolling, allowing the player to kill while rolling.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("This hitbox becomes harmful while rolling, allowing the player to kill while rolling.")]
        public SonicHitbox Hitbox;

        
        /// <summary>
        /// Change in width (usually negative) while rolling, in units.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Change in sensor width (usually negative) while rolling, in units.")]
        public float WidthChange;

        /// <summary>
        /// Change in sensor height (usually negative) while rolling, in units. The script makes sure that
        /// the controller's ground sensors are still on the ground after the height change.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Change in sensor height (usually negative) while rolling, in units. The script makes sure " +
                 "that the controller's ground sensors are still on the ground after the height change.")]
        public float HeightChange;

        /// <summary>
        /// Slope gravity when rolling uphill, in units per second squared.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Slope gravity when rolling uphill, in units per second squared.")]
        public float UphillGravity;

        /// <summary>
        /// Slope gravity when rolling downhill, in units per second squared.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Slope gravity when rolling downhill, in units per second squared.")]
        public float DownhillGravity;

        /// <summary>
        /// Deceleration while rolling, in units per second squared.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Deceleration while rolling, in units per second squared.")]
        public float Deceleration;

        /// <summary>
        /// Friction while rolling, in units per second squared.
        /// </summary>
        [PhysicsFoldout]
        [Tooltip("Friction while rolling, in units per second squared.")]
        public float Friction;
        #endregion
        #region Animation
        /// <summary>
        /// Name of an Animator bool set to whether the controller is going uphill.
        /// </summary>
        [AnimationFoldout]
        [Tooltip("Name of an Animator bool set to whether the controller is going uphill.")]
        public string UphillBool;
        protected int UphillBoolHash;
        #endregion

        [SoundFoldout]
        public AudioClip RollSound;
        [SoundFoldout]
        public AudioSource RollSoundSource;
        [SoundFoldout]
        public AudioSource SpindashSoundSource;
        private bool _rightDirection;

        private float _originalSlopeGravity;
        private float _originalFriction;
        private float _originalDeceleration;

        public bool Uphill;

        protected ScoreCounter Score;
        protected GroundControl GroundControl;

        public override MoveLayer Layer
        {
            get { return MoveLayer.Roll; }
        }

        public override void Reset()
        {
            base.Reset();

            UphillBool = "";

            ActivateAxis = "Vertical";
            RequireNegative = true;
            MinActivateSpeed = 0.61875f;

            Hitbox = Controller.GetComponentInChildren<SonicHitbox>();
            HeightChange = -0.10f;
            WidthChange = -0.04f;
            UphillGravity = 2.8125f;
            DownhillGravity = 11.25f;
            Friction = 0.8451f;
            Deceleration = 4.5f;
        }

        public override void Awake()
        {
            base.Awake();
            _rightDirection = false;
            Uphill = false;

            UphillBoolHash = string.IsNullOrEmpty(UphillBool) ? 0 : Animator.StringToHash(UphillBool);
            RollSoundSource.volume = 1;
        }

        public override void Start()
        {
            
            base.Start();
            Controller.OnAttach.AddListener(OnAttach);
            Score = Controller.GetComponent<ScoreCounter>();
            RollSoundSource.volume = 1;

        }

        public override void OnManagerAdd()
        {
            GroundControl = Manager.Get<GroundControl>();
        }

        protected void OnAttach()
        {
            End();
        }

        public override bool Available
        {
            get { return Controller.Grounded; }
        }

        public override bool ShouldEnd
        {
            get
            {
                if (!Controller.Grounded && Controller.SurfaceAngle == 0) return false;
                return (_rightDirection && Controller.GroundVelocity < 0f && Controller.GroundVelocity > -MinActivateSpeed) ||
                       (!_rightDirection && Controller.GroundVelocity > 0f && Controller.GroundVelocity < MinActivateSpeed);
            }
        }

        public override bool ShouldPerform
        {
            get { return (RequireNegative ? Input.GetAxisRaw(ActivateAxis) < 0 : Input.GetAxisRaw(ActivateAxis) > 0) && Mathf.Abs(Controller.GroundVelocity) >= MinActivateSpeed || Physics2D.Raycast(Controller.transform.position, -Controller.transform.up).collider.gameObject.layer == 31 && Manager.Get<Jump>();  }
        }

        public override void SetAnimatorParameters()
        {
            base.SetAnimatorParameters();

            if (!string.IsNullOrEmpty(UphillBool))
                Controller.Animator.SetBool(UphillBool, Uphill);
        }
        public override void Update()
        {
            base.Update();
            
        }
        public override void OnActiveEnter(State previousState)
        {
            
            base.OnActiveEnter();
            if(!SpindashSoundSource.isPlaying && Controller.Grounded)
            {
                RollSoundSource.clip = RollSound;
                RollSoundSource.pitch = 1;
                RollSoundSource.volume = 1;
                RollSoundSource.Play();
            }
            IsRolling = true;
            // Store original physics values to restore after leaving the roll
            _rightDirection = Controller.GroundVelocity > 0.0f;

            _originalSlopeGravity = Controller.SlopeGravity;
            _originalFriction = Controller.GroundFriction;
            _originalDeceleration = GroundControl.Deceleration;

            Controller.GroundFriction = Friction;
            
            GroundControl.Deceleration += Deceleration;

            Controller.Sensors.TopOffset += HeightChange/2.0f;
            Controller.Sensors.BottomOffset -= HeightChange/2.0f;

            Controller.Sensors.LedgeWidth += WidthChange;
            Controller.Sensors.BottomWidth += WidthChange;
            Controller.Sensors.TopWidth += WidthChange;

            Hitbox.Harmful = true;


        }
        
        bool hush;
        public override void OnActiveFixedUpdate()
        {
            
            
            base.OnActiveFixedUpdate();
            var previousUphill = Uphill;
            Animator.SetFloat("RollSpeed", Animator.GetFloat("Absolute Ground Speed") + (Animator.GetFloat("Absolute Ground Speed") < 0.2f && !Controller.Grounded ? 1.6f : 0));

            if (Controller.GroundVelocity > 0.0f)
            {
                Uphill = DMath.AngleInRange_d(Controller.RelativeSurfaceAngle, 0.0f, 180.0f);
            } else if (Controller.GroundVelocity < 0.0f)
            {
                Uphill = DMath.AngleInRange_d(Controller.RelativeSurfaceAngle, 180.0f, 360.0f);
            }

            if (Controller.SlopeGravity != (previousUphill ? UphillGravity : DownhillGravity))
                _originalSlopeGravity = Controller.SlopeGravity;

            Controller.SlopeGravity = Uphill ? UphillGravity : DownhillGravity;
            if(Controller.Grounded && Controller.GroundVelocity == 0) { End();}
        }
        public override void OnActiveExit()
        {
            base.OnActiveExit();
            IsRolling = false;
            Controller.SlopeGravity = _originalSlopeGravity;
            Controller.GroundFriction = _originalFriction;
            GroundControl.AccelerationLocked = false;
            GroundControl.Deceleration = _originalDeceleration;

            Controller.Sensors.TopOffset -= HeightChange/2.0f;
            Controller.Sensors.BottomOffset += HeightChange/2.0f;

            Controller.Sensors.LedgeWidth -= WidthChange;
            Controller.Sensors.BottomWidth -= WidthChange;
            Controller.Sensors.TopWidth -= WidthChange;

            Hitbox.Harmful = false;

            if(Score) Score.EndCombo();
        }
    }
}
