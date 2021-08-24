using UnityEngine;

namespace WheelApps {
    public class AirplaneEngine : MonoBehaviour {
        #region Variables
        public float maxForce = 5000f;
        public float maxRPM = 2550f;
        #endregion
        
        #region Builtin Methods
        #endregion
        
        #region Custom Methods
        public Vector3 CalculateForce(float throttle) {
            var finalThrottle = Mathf.Clamp01(throttle);
            var finalPower = finalThrottle * maxForce;
            var finalForce = finalPower * transform.forward;
            return finalForce;
        }
        #endregion
    }
}