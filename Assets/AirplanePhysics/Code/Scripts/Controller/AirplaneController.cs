﻿using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] private bool isGrounded = true;
        #endregion
        
        
        
        #region Constants
        private const float poundsToKillos = 0.453592f;
        private const float metersToFeet = 3.28084f;
        #endregion



        #region Properties
        private float currentMSL;
        public float CurrentMSL => currentMSL;

        private float currentAGL;
        public float CurrentAGL => currentAGL;
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
            
            InvokeRepeating(nameof(CheckGrounded), 2f, 1f);
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
            foreach (var engine in engines) rb.AddForce(engine.CalculateForce(input.StickyThrottle));
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
            currentMSL = transform.position.y * metersToFeet;
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, Vector3.down, out hit)) return;
            if (hit.transform.CompareTag(Tags.Ground)) currentAGL = (transform.position.y - hit.point.y) * metersToFeet;
        }

        
        private void GetPresetInfo() {
            if (!preset) return;
            airplaneWeight = preset.airplaneWeight;
            centerOfMass.localPosition = preset.comPosition;

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


        private void CheckGrounded() {
            if (wheels.Count <= 0) return;
            var grounded = wheels.Count(wheel => wheel.IsGrounded);
            isGrounded = grounded.Equals(wheels.Count);
        }
        #endregion
    }
}