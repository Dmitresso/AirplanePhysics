using UnityEngine;

namespace WheelApps {
    public class AirplaneTachometer : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Tachometer Properties")]
        public AirplaneEngine engine;
        public RectTransform pointer;
        public float maxRPM = 3500f;
        public float maxRotation = 312f;
        public float pointerSpeed = 2f;

        private float finalRotation;
        #endregion



        #region Interface Methods
        public void HandleAirplaneUI() {
            if (!engine || !pointer) return;
            var normalizedRPM = Mathf.InverseLerp(0f, maxRPM, engine.CurrentRPM);
            var targetRotation = maxRotation * -normalizedRPM;
            finalRotation = Mathf.Lerp(finalRotation, targetRotation, pointerSpeed * Time.deltaTime);
            
            pointer.rotation = Quaternion.Euler(0f, 0f, finalRotation);
        }
        #endregion
    }
}