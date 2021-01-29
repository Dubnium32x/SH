using UnityEngine;
public class MoveBackground : MonoBehaviour{[Tooltip("The speed of which the sprite moves")] public Vector3 Speed; [Tooltip("Where to reset the animation")] public Vector3 StopAt;[Tooltip("Where to reset")] public Vector3 ResetPos; void FixedUpdate(){transform.Translate(Speed,Space.Self); if (transform.position.x>StopAt.x){ transform.position=ResetPos;}}}
