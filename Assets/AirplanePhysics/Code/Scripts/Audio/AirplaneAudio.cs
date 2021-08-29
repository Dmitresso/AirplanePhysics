using System;
using UnityEngine;

namespace WheelApps {
    public class AirplaneAudio : MonoBehaviour {
        #region Variables
        [Header("Airplane Audio Properties")]
        public BaseAirplaneInput input;
        public AudioSource idleSrc;
        public AudioSource fullThrottleSrc;

        #endregion



        #region Builtin Methods
        private void Update() {
            if (!input) return;
            HandleAudio();    
        }
        #endregion



        #region Custom Methods
        protected virtual void HandleAudio() {
            
        }
        #endregion
    }
}