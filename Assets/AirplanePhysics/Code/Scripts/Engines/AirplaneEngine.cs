using UnityEngine;

namespace WheelApps {
    public class AirplaneEngine : MonoBehaviour {
        #region Variables
        [Header("Engine Properties")]
        public float maxForce = 5000f;
        public float maxRPM = 2550f;
        public float shutOffSpeed = 2f;
        
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellers")]
        public AirplanePropeller propeller;

        private bool isShutOff;
        private float lastThrottle;
        private float finalShutoffThrollte;
        #endregion



        #region Properties
        public bool ShutEngineOff {
            set => isShutOff = value;
        }

        private float currentRPM;
        public float CurrentRPM => currentRPM;
        #endregion
        
        
        
        #region Builtin Methods
        #endregion
        
        
        
        
        #region Custom Methods
        public Vector3 CalculateForce(float throttle) {
            var finalThrottle = Mathf.Clamp01(throttle);

            if (!isShutOff) {
                finalThrottle = powerCurve.Evaluate(finalThrottle);
                lastThrottle = finalThrottle;
            }
            else {
                lastThrottle -= Time.deltaTime * shutOffSpeed;
                lastThrottle = Mathf.Clamp01(lastThrottle);
                finalThrottle = finalShutoffThrollte;
            }

            currentRPM = finalThrottle * maxRPM;

            if (propeller) propeller.HandlePropeller(finalThrottle * maxRPM);

            var finalPower = finalThrottle * maxForce;
            var finalForce = finalPower * transform.forward;
            
            return finalForce;
        }
        #endregion
    }
}