using UnityEngine;
using SonicRealms.Core.Actors;
using SonicRealms.Core.Triggers;
using SonicRealms.Core.Utils;

namespace SonicRealms.Level.Objects
{
    public class Checkpoint : ReactiveObject
    {
        /// <summary>
        /// Name of an Animator trigger set when the checkpoint is immediately activated.
        /// </summary>
        [Foldout("Animation")]
        public string ActivateImmediateTrigger;
        protected int ActivateImmediateTriggerHash;

        [Foldout("Debug")]
        public bool ActivatedImmediately;

        public override void Awake()
        {
            base.Awake();
            ActivateImmediateTriggerHash = Animator.StringToHash(ActivateImmediateTrigger);
        }

        public override void OnActivate(HedgehogController controller = null)
        {
            SDDM.Modify(SDR.SDVint("CurrentFileLoaded").ToString() + "CheckpointX: ", controller.transform.position.x.ToString());

            SDDM.Modify(SDR.SDVint("CurrentFileLoaded").ToString() + "CheckpointY: ", controller.transform.position.y.ToString());

            SDDM.Modify(SDR.SDVint("CurrentFileLoaded").ToString() + "CheckpointZ: ", controller.transform.position.z.ToString());
            Debug.Log("Can Can Can Can Can Can Can Can Can Can Can Can");

            ObjectTrigger.enabled = false;
        }

        /// <summary>
        /// Use this to turn on the checkpoint when the level starts.
        /// </summary>
        public virtual void ActivateImmediate()
        {
            ActivatedImmediately = true;
            ObjectTrigger.enabled = false;
            if (Animator != null && ActivateImmediateTriggerHash != 0)
                Animator.SetTrigger(ActivateImmediateTriggerHash);
        }
    }
}
