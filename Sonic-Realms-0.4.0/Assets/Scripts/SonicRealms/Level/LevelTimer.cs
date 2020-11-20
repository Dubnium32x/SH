using System;
using UnityEngine;
using SonicRealms.Core.Actors;

namespace SonicRealms.Level
{
    public class LevelTimer : MonoBehaviour
    {
        public TimeSpan Time;

        public void Update()
        {
            if (!HedgehogController.DebugOnS)
            {
                Time = Time.Add(TimeSpan.FromSeconds(UnityEngine.Time.deltaTime));
            }
            
        }
        
    }
}
