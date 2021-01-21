using SonicRealms.Level;
using UnityEngine;

namespace SonicRealms.Core.Moves
{
    /// <summary>
    /// Handles the braking sound when Sonic skids to a halt.
    /// </summary>
    [RequireComponent(typeof(GroundControl))]
    public class Skid : Move
    {
        /// <summary>
        /// Minimum speed at which skidding occurs, in units per second.
        /// </summary>
        [ControlFoldout]
        [Tooltip("Minimum speed at which skidding occurs, in units per second.")]
        public float MinimumSpeed;

        /// <summary>
        /// The Sound's audioSource. Since .PlayOneShot has drinking issues
        /// </summary>
        [SoundFoldout]
        [Tooltip("The Sound's audioSource. Since .PlayOneShot has drinking issues")]
        public AudioSource SkidSoundSource;

        /// <summary>
        /// Sound that gets played after Sonic is skid.
        /// </summary>
        [SoundFoldout]
        [Tooltip("Sound that gets played during a skid.")]
        public AudioClip SkidSound;

        /// <summary>
        /// Point at which the skid sound loops, in seconds.
        /// </summary>
        [SoundFoldout]
        [Tooltip("Point at which the skid sound loops, in seconds.")]
        public float SkidSoundRepeatTime;

        public static bool IsSkid;
        protected GroundControl GroundControl;

        public override MoveLayer Layer
        {
            get { return MoveLayer.Action; }
        }

        public override bool Available
        {
            get { return Controller.Grounded && Mathf.Abs(Controller.GroundVelocity) > MinimumSpeed; }
        }

        public override bool ShouldPerform
        {
            get { return GroundControl.Braking && Manager[MoveLayer.Action] == null && Manager[MoveLayer.Roll] == null; }
        }

        public override bool ShouldEnd
        {
            get { return !Controller.Grounded || !GroundControl.Braking || Manager[MoveLayer.Roll] != null; }
        }

        public override void Reset()
        {
            base.Reset();

            MinimumSpeed = 2.7f;
            SkidSoundRepeatTime = 0.0667f;
        }
        public override void OnActiveEnter()
        {
            base.OnActiveEnter();
            SkidSoundSource.clip = SkidSound;
            SkidSoundSource.Play();
        }
        public override void Start()
        {
            base.Start();
            GroundControl = Manager.Get<GroundControl>();
            
        }
        public override void OnActiveUpdate()
        {
            base.OnActiveUpdate();
            if (SkidSoundSource.time > SkidSoundRepeatTime) { SkidSoundSource.Play();  }
            IsSkid = true;
        }
        public override void OnActiveExit()
        {
            base.OnActiveExit();
            IsSkid = false;
        }
    }
}
