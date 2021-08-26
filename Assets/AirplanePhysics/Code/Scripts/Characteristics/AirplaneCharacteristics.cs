﻿using UnityEngine;

namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float mph;
        public float maxMPH = 110f;

        [Header("Lift Properties")]
        public float maxLiftPower = 4000f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        
        [Header("Drag Properties")]
        public float dragFactor = 0.01f;

        [Header("Control Properties")]
        public float pitchSpeed = 10f;
        public float rollSpeed = 10f;
        

        private BaseAirplaneInput input;
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        private float maxMPS;
        private float normalizeMPH;
        private float angleOfAttack;
        private float pitchAngle;
        private float rollAngle;
        #endregion



        #region Constants
        public const float mpsToMph = 2.23694f;
        #endregion
        
        

        #region Builtin Methods
        #endregion



        #region Custom Methods
        public void Init(Rigidbody rb, BaseAirplaneInput input) {
            this.rb = rb;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;

            this.input = input;
            
            maxMPS = maxMPH / mpsToMph;
        }

        public void Update() {
            if (!rb) return;
            CalculateForwardSpeed();
            CalculateLift();
            CalculateDrag();

            HandlePitch();
            HandleRoll();
            HandleRBTransform();
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
            angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
            angleOfAttack *= angleOfAttack;
            
            var liftDirection = transform.up;
            var liftPower = liftCurve.Evaluate(normalizeMPH) * maxLiftPower;
            var finalLiftForce = liftDirection * liftPower * angleOfAttack;
            rb.AddForce(finalLiftForce);
        }

        private void CalculateDrag() {
            var speedDrag = forwardSpeed * dragFactor;
            var finalDrag = startDrag + speedDrag;

            rb.drag = finalDrag;
            rb.angularDrag = startAngularDrag * forwardSpeed;
        }

        private void HandlePitch() {
            var flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            pitchAngle = Vector3.Angle(transform.forward, flatForward);

            var pitchTorque = input.Pitch * pitchSpeed * transform.right;
            rb.AddTorque(pitchTorque);
        }


        private void HandleRoll() {
            var flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            rollAngle = Vector3.Angle(transform.right, flatRight);

            var rollTorque = - input.Roll * rollSpeed * transform.forward;
            rb.AddTorque(rollTorque);
        }
        
        private void HandleRBTransform() {
            if (!(rb.velocity.magnitude > 1f)) return;
            
            var updatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime);
            rb.velocity = updatedVelocity;
            
            var updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime);
            rb.MoveRotation(updatedRotation);
        }
        #endregion
    }
}