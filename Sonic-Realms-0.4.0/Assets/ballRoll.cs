using UnityEngine;
using SonicRealms.Core.Actors;

namespace SonicRealms.Core.Moves
{
    public class ballRoll : MonoBehaviour
    {
        public Transform SpriteT;
        public float HitR;
        public float HitL;
        public float Spins;
        public void Reset()
        {
            Spins = 256;
        }
        void FixedUpdate()
        {
            SpriteT.Rotate(0,0,-GetComponent<HedgehogController>().GroundVelocity * 256 * Time.deltaTime, Space.Self);
        }

    }
}