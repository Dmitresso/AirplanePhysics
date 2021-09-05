using UnityEngine;


namespace WheelApps {
    public class AirplaneFuelGauge : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Fuel Gauge Properties")]
        public AirplaneFuel fuel;
        public RectTransform pointer;
        public Vector2 minMaxRotation = new Vector2(-90f, 90f);
        #endregion


        
        #region Builtin Methods
        public void HandleAirplaneUI() {
            if (fuel && pointer) {
                var targetRotation = Mathf.Lerp(minMaxRotation.x, minMaxRotation.y, fuel.NormalizedFuel);
                pointer.rotation = Quaternion.Euler(0f, 0f, - targetRotation);
            }
        }
        #endregion
    }
}