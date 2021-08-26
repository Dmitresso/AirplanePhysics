

using UnityEngine;

namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float mph;
        public float maxMPH = 110f;

        [Header("Lift Properties")]
        public float maxLiftPower = 800f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        private float maxMPS;
        
        private float normalizeMPH;
        #endregion



        #region Constants
        public const float mpsToMph = 2.23694f;
        #endregion
        
        

        #region Builtin Methods

        

        #endregion



        #region Custom Methods
        public void Init(Rigidbody rb) {
            this.rb = rb;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
            maxMPS = maxMPH / mpsToMph;
        }

        public void Update() {
            if (!rb) return;
            CalculateForwardSpeed();
            CalculateLift();
            CalculateDrag();
        }

        private void CalculateForwardSpeed() {
            var localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = Mathf.Max(0, localVelocity.z);
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxMPS);
            
            mph = forwardSpeed * mpsToMph;
            mph = Mathf.Clamp(mph, 0, maxMPH);
            normalizeMPH = Mathf.InverseLerp(0, maxMPH, mph);
        }

        private void CalculateLift() {
            var liftDirection = transform.up;
            var liftPower = liftCurve.Evaluate(normalizeMPH) * maxLiftPower;
            var finalLiftForce = liftDirection * liftPower;
            rb.AddForce(finalLiftForce);
        }

        private void CalculateDrag() {
            
        }
        #endregion
    }
}