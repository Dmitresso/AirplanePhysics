using UnityEngine;


namespace WheelApps {
    public class AirplaneAirspeed : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Airspeed Indicator Properties")]
        public AirplaneCharacteristics characteristics;
        public RectTransform pointer;
        public float maxIndicatedKnots = 160f;
        #endregion



        #region Constants
        public const float mphToKnots = 0.868976f;
        #endregion

        

        #region Interface Methods
        public void HandleAirplaneUI() {
            if(!characteristics || !pointer) return;
            var currentKnots = characteristics.MPH * mphToKnots;
            var normalizedKnots = Mathf.InverseLerp(0f, maxIndicatedKnots, currentKnots);
            var targetRotation = normalizedKnots * 360f;
            pointer.rotation = Quaternion.Euler(0f, 0f, - targetRotation);
        }
        #endregion
    }
}