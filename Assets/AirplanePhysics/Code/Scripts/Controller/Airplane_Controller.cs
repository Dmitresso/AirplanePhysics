using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    public class Airplane_Controller : BaseRigidbody_Controller {
        #region Variables
        [Header("Base Airplane Properties")]
        public BaseAirplane_Input input;
        [Tooltip("Weight in LBS")]
        public float airplaneWeight = 1200f;
        public Transform centerOfMass;
        [Header("Engines")]
        public List<AirplaneEngine> engines = new List<AirplaneEngine>();

        [Header("Wheels")]
        public List<AirplaneWheel> wheels = new List<AirplaneWheel>();
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
            if (wheels != null && wheels.Count > 0) {
                foreach (var wheel in wheels) wheel.Init();
            }
        }

        #endregion
        
        
        
        #region Custom Methods
        protected override void HandlePhysics() {
            if (!input) return; 
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }

        private void HandleEngines() {
            if (engines == null || engines.Count <= 0) return;
            foreach (var engine in engines) rb.AddForce(engine.CalculateForce(input.Throttle));
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