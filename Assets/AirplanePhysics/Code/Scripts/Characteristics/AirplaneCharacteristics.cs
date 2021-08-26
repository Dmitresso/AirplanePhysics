

using UnityEngine;

namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float mph;

        [Header("Lift Properties")]
        public float maxLiftPower = 600f;
        
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;
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
            mph = forwardSpeed * mpsToMph;
        }

        private void CalculateLift() {
            var liftDirection = transform.up;
            var liftPower = forwardSpeed * maxLiftPower;
            var finalLiftForce = liftDirection * liftPower;
            rb.AddForce(finalLiftForce);
        }

        private void CalculateDrag() {
            
        }
        #endregion
    }
}