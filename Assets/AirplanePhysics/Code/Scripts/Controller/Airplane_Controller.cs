using UnityEngine;

namespace WheelApps {
    public class Airplane_Controller : BaseRigidbody_Controller {
        #region Variables
        [Header("Base Airplane Properties")]
        public XboxAirplane_Input input;
        [Tooltip("Weight in LBS")]
        public float airplaneWeight = 800f;
        public Transform centerOfMass;

        #endregion
        
        
        
        #region Constants
        private const float poundsToKillos = 0.453592f; 
        #endregion
        
        
        
        #region Builtin Methods
        public override void Start() {
            base.Start();
            var finalMass = airplaneWeight * poundsToKillos;
            if (!rb) return;
            rb.mass = finalMass;
            if (centerOfMass) rb.centerOfMass = centerOfMass.localPosition;
        }

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