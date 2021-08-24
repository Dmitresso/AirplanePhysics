using UnityEngine;

namespace WheelApps {
    public class AirplaneEngine : MonoBehaviour {
        #region Variables
        public float maxForce = 5000f;
        public float maxRPM = 2550f;
        
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        #endregion
        
        #region Builtin Methods
        #endregion
        
        #region Custom Methods
        public Vector3 CalculateForce(float throttle) {
            var finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);
            
            var finalPower = finalThrottle * maxForce;
            var finalForce = finalPower * transform.forward;
            
            return finalForce;
        }
        #endregion
    }
}