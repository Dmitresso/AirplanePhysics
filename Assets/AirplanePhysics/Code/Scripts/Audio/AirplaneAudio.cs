using UnityEngine;


namespace WheelApps {
    public class AirplaneAudio : MonoBehaviour {
        #region Variables
        [Header("Airplane Audio Properties")]
        public BaseAirplaneInput input;
        public AudioSource idleSrc;
        public AudioSource fullThrottleSrc;
        public float maxPitch = 1.2f;

        private float finalVolume;
        private float finalPitch;
        #endregion



        #region Builtin Methods
        private void Start() {
            if (fullThrottleSrc) fullThrottleSrc.volume = 0f;
            
        }

        
        private void Update() {
            if (!input) return;
            HandleAudio();    
        }
        #endregion



        #region Custom Methods
        protected virtual void HandleAudio() {
            finalVolume = Mathf.Lerp(0f, 1f, input.Throttle);
            finalPitch = Mathf.Lerp(1f, maxPitch, input.Throttle);

            if (!fullThrottleSrc) return;
            fullThrottleSrc.volume = finalVolume;
            fullThrottleSrc.pitch = finalPitch;
        }
        #endregion
    }
}