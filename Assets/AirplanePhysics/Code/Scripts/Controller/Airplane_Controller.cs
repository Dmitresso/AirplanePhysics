using UnityEngine;

namespace WheelApps {
    public class Airplane_Controller : BaseRigidbody_Controller {
        #region Variables
        [Header("Base Airplane Properties")]
        public XboxAirplane_Input input;
        [Tooltip("Weight in LBS")]
        public float airplaneWeight = 800f;
        public Transform centerOfGravity;

        #endregion
        
        
        
        #region Custom Methods
        protected override void HandlePhysics() {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }

        private void HandleEngines() {
            
        }

        private void HandleAerodynamics() {
            
        }

        private void HandleSteering() {
            
        }

        private void HandleBrakes() {
            
        }

        private void HandleAltitude() {
            
        }
        #endregion
    }
}