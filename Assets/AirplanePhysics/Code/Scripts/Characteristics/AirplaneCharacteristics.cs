

using UnityEngine;

namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float mph;
        
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
            forwardSpeed = localVelocity.z;
            mph = forwardSpeed * mpsToMph;
        }

        private void CalculateLift() {
            
        }

        private void CalculateDrag() {
            
        }
        #endregion
    }
}