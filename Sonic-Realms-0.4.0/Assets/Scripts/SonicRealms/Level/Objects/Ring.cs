using SonicRealms.Core.Actors;
using SonicRealms.Core.Triggers;
using UnityEngine;
using SonicRealms.Core.Moves;
namespace SonicRealms.Level.Objects
{
    /// <summary>
    /// A ring that can be collected.
    /// </summary>

    public class Ring : ReactiveArea
    {

   GameObject RingAudioSourcePrefab;
        /// <summary>
        /// How many rings to give when collected.
        /// </summary>
        [Tooltip("How many rings to give when collected.")]
        public int Value;

        /// <summary>
        /// Name of an Animator trigger set when collected.
        /// </summary>
        [Tooltip("Name of an Animator trigger set when collected.")]
        public string CollectedTrigger;
        protected int CollectedTriggerHash;

        /// <summary>
        /// Whether the ring has been collected.
        /// </summary>
        [Tooltip("Whether the ring has been collected.")]
        public bool Collected;

        /// <summary>
        /// An audio clip to play when the ring is collected.
        /// </summary>
        [Tooltip("An audio clip to play when the ring is collected.")]
        public AudioClip CollectedSound;

        public GameObject RingCollectSoundTruePrefab;
        /// <summary>
        /// Next ring sound will pan right if true, pan left otherwise.
        /// </summary>
        static bool PanRight;
        public void Update()
        {
            PanRight = GameObject.FindGameObjectWithTag("Player").GetComponent<RingCounter>().Rings % 2 == 1;
        }
        public override void Reset()
        {
            base.Reset();
            Value = 1;
            CollectedTrigger = "";
            CollectedSound = null;
            
        }
        string buddyWeHaveALotToDiscuss;
        public override void Awake()
        {
            
            base.Awake();
            Collected = false;
            
            if (Animator != null && !string.IsNullOrEmpty(CollectedTrigger))
                CollectedTriggerHash = Animator.StringToHash(CollectedTrigger);
        }

        public override void OnAreaStay(Hitbox hitbox)
        { if (!Death.IsDead) {
                var controller = hitbox.Controller;
                if (Collected) return;
                var collector = controller.GetComponent<RingCounter>();
                if (collector == null || !collector.CanCollect) return;

                collector.Rings += Value;
                
                if (Animator != null && CollectedTriggerHash != 0)
                    Animator.SetTrigger(CollectedTriggerHash);

                Collected = true;

                if (CollectedSound != null)
                {
                    if (PanRight) { GameObject.FindGameObjectWithTag("RingSoundR").GetComponent<AudioSource>().Play(); }
                    if (!PanRight) { GameObject.FindGameObjectWithTag("RingSoundL").GetComponent<AudioSource>().Play(); }
                }

                TriggerObject(controller);
            } }
    }
}