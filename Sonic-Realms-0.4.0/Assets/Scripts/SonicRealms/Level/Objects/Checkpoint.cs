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
        [Foldout("Hit Box")]
        public Vector3 BoxSize;
        [Foldout("Great value")]
        public int CheckpointID;
        public override void Awake()
        {
            base.Awake();
            ActivateImmediateTriggerHash = Animator.StringToHash(ActivateImmediateTrigger);
        }
        public void Update()
        {
            if (SDR.SDVint(SDR.CheckpointsActivated) >= CheckpointID) { ActivatedImmediately = true; ObjectTrigger.enabled = false; if (Animator != null && ActivateImmediateTriggerHash != 0)
                    Animator.SetTrigger(ActivateImmediateTriggerHash);
            }
        }
        public override void OnActivate(HedgehogController controller = null)
        {

            ObjectTrigger.enabled = false;

            /*SDDM.Modify(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointX: ", SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointX: " + GameObject.FindGameObjectWithTag("Player").transform.position.x.ToString());
            SDDM.Modify(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointY: ", SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointY: " + GameObject.FindGameObjectWithTag("Player").transform.position.y.ToString());
            SDDM.Modify(SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointZ: ", SDR.SDVint("CurrentFileLoaded: ").ToString() + "CheckpointZ: " + GameObject.FindGameObjectWithTag("Player").transform.position.z.ToString());*/

            SDDM.Modify(SDR.CheckpointPosition[0], SDR.CheckpointPosition[0] + (transform.position.x).ToString());
            SDDM.Modify(SDR.CheckpointPosition[1], SDR.CheckpointPosition[1] + (transform.position.y).ToString());
            SDDM.Modify(SDR.CheckpointPosition[2], SDR.CheckpointPosition[2] + (transform.position.z).ToString());
			

            int thing = SDR.SDVint(SDR.CheckpointsActivated) < CheckpointID ? (SDR.SDVint(SDR.CheckpointsActivated) + 1) : SDR.SDVint(SDR.CheckpointsActivated);

            string stringthing = thing.ToString();
            SDDM.Modify(SDR.CheckpointsActivated, SDR.CheckpointsActivated + 
                 stringthing);
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
