using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(AirplaneCharacteristics))]
    public class AirplaneController : BaseRigidbodyController {
        #region Variables
        [Header("Base Airplane Properties")]
        public AirplanePreset preset;
        public BaseAirplaneInput input;
        public AirplaneCharacteristics characteristics;
        
        [Tooltip("Weight in LBS")]
        public float airplaneWeight = 1200f;
        public Transform centerOfMass;
        
        [Header("Engines")]
        public List<AirplaneEngine> engines = new List<AirplaneEngine>();

        [Header("Wheels")]
        public List<AirplaneWheel> wheels = new List<AirplaneWheel>();

        [Header("Control Surfaces")]
        public List<AirplaneControlSurface> controlSurfaces = new List<AirplaneControlSurface>();
        #endregion
        
        
        
        #region Constants
        private const float poundsToKillos = 0.453592f; 
        #endregion
        
        
        
        #region Builtin Methods
        public override void Start() {
            GetPresetInfo();
            
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
            HandleControlSurfaces();
            HandleWheel();
            HandleAltitude();
        }

        
        private void HandleEngines() {
            if (engines == null || engines.Count <= 0) return;
            foreach (var engine in engines) rb.AddForce(engine.CalculateForce(input.Throttle));
        }

        
        private void HandleCharacteristics() {
            if (characteristics) characteristics.Update();
        }


        private void HandleControlSurfaces() {
            if (controlSurfaces.Count <= 0) return;
            foreach (var cs in controlSurfaces) {
                cs.HandleControlSurface(input);
            }
        }


        private void HandleWheel() {
            if (wheels.Count <= 0) return;
            foreach (var wheel in wheels) wheel.HandleWheel(input);
        }
        
        
        private void HandleAltitude() {
            
        }

        private void GetPresetInfo() {
            if (!preset) return;
            airplaneWeight = preset.airplaneWeight;
            centerOfMass.position = preset.comPosition;

            if (!characteristics) return;
            characteristics.maxMPH = preset.maxMPH;
            characteristics.rbLerpSpeed = preset.rbLerpSpeed;
            characteristics.maxLiftPower = preset.maxLiftPower;
            characteristics.liftCurve = preset.liftCurve;
            characteristics.dragFactor = preset.dragFactor;
            characteristics.flapDragFactor = preset.flapDragFactor;
            characteristics.pitchSpeed = preset.pitchSpeed;
            characteristics.rollSpeed = preset.rollSpeed;
            characteristics.yawSpeed = preset.yawSpeed;
        }
        #endregion
    }
}