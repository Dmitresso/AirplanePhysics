using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(AirplaneCharacteristics))]
    public class AirplaneController : BaseRigidbodyController {
        #region Variables
        [Header("Base Airplane Properties")]
        public BaseAirplaneInput input;
        public AirplaneCharacteristics characteristics;
        
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

            if (wheels != null && wheels.Count > 0) {
                foreach (var wheel in wheels) wheel.Init();
            }
            
            if (!rb) return;
            rb.mass = finalMass;
            if (centerOfMass) rb.centerOfMass = centerOfMass.localPosition;
            characteristics = GetComponent<AirplaneCharacteristics>();
            if (characteristics) characteristics.Init(rb, input);
        }

        #endregion
        
        
        
        #region Custom Methods
        protected override void HandlePhysics() {
            if (!input) return; 
            HandleEngines();
            HandleCharacteristics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }

        private void HandleEngines() {
            if (engines == null || engines.Count <= 0) return;
            foreach (var engine in engines) rb.AddForce(engine.CalculateForce(input.Throttle));
        }

        private void HandleCharacteristics() {
            if (characteristics) characteristics.Update();
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