

using UnityEngine;

namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;
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
            
        }

        private void CalculateLift() {
            
        }

        private void CalculateDrag() {
            
        }
        #endregion
    }
}