using UnityEngine;


namespace WheelApps {
    public class AirplaneCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Characteristics Properties")]
        public float maxMPH = 110f;
        public float rbLerpSpeed = 0.03f;

        [Header("Lift Properties")]
        public float maxLiftPower = 5000f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public float flapLiftPower = 100f;
        
        [Header("Drag Properties")]
        public float dragFactor = 0.0004f;
        public float flapDragFactor = 0.0004f;

        [Header("Control Properties")]
        public float pitchSpeed = 1000f;
        public float rollSpeed = 1000f;
        public float yawSpeed = 1000f;
        public AnimationCurve controlSurfaceEfficiency = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        

        private float forwardSpeed;
        public float ForwardSpeed => forwardSpeed;

        private float mph;
        public float MPH => mph;
        
        
        private BaseAirplaneInput input;
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        private float maxMPS;
        private float normalizeMPH;
        private float angleOfAttack;
        private float pitchAngle;
        private float rollAngle;

        private float csEfficiency;
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

            HandleControlSurfaceEfficiency();
            HandlePitch();
            HandleRoll();
            HandleYaw();
            HandleBanking();
            HandleRBTransform();
        }

        
        private void CalculateForwardSpeed() {
            var localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = Mathf.Max(0f, localVelocity.z);
            // forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxMPS);
            
            
            mph = forwardSpeed * mpsToMph;
            //mph = Mathf.Clamp(mph, 0, maxMPH);
            normalizeMPH = Mathf.InverseLerp(0f, maxMPH, mph);
        }

        
        private void CalculateLift() {
            angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
            angleOfAttack *= angleOfAttack;
            
            var liftDirection = transform.up;
            var liftPower = liftCurve.Evaluate(normalizeMPH) * maxLiftPower;

            var finalLiftPower = flapLiftPower * input.NormalizedFlaps;
            
            var finalLiftForce = liftDirection * (liftPower + finalLiftPower) * angleOfAttack;
            rb.AddForce(finalLiftForce);
        }

        
        private void CalculateDrag() {
            var speedDrag = forwardSpeed * dragFactor;
            var flapDrag = input.Flaps * flapDragFactor;
            
            var finalDrag = startDrag + speedDrag + flapDrag;

            rb.drag = finalDrag;
            rb.angularDrag = startAngularDrag * forwardSpeed;
        }

        
        private void HandleControlSurfaceEfficiency() {
            csEfficiency = controlSurfaceEfficiency.Evaluate(normalizeMPH);
            
        }
        
        
        private void HandlePitch() {
            var flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            pitchAngle = Vector3.Angle(transform.forward, flatForward);

            var pitchTorque = input.Pitch * pitchSpeed * csEfficiency * transform.right;
            rb.AddTorque(pitchTorque);
        }


        private void HandleRoll() {
            var flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);

            var rollTorque = - input.Roll * rollSpeed * csEfficiency * transform.forward;
            rb.AddTorque(rollTorque);
        }

        
        private void HandleYaw() {
            var yawTorque = input.Yaw * yawSpeed * csEfficiency * transform.up;
            rb.AddTorque(yawTorque);
        }


        private void HandleBanking() {
            var bankSide = Mathf.InverseLerp(-90f, 90f, rollAngle);
            var bankAmount = Mathf.Lerp(-1f, 1f, bankSide);
            var bankTorque = bankAmount * rollSpeed * transform.up;
            rb.AddTorque(bankTorque);
        }
        
        
        private void HandleRBTransform() {
            if (rb.velocity.magnitude <= 1f) return;
            
            var updatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * rbLerpSpeed * Time.deltaTime);
            rb.velocity = updatedVelocity;
            
            var updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), rbLerpSpeed * Time.deltaTime);
            rb.MoveRotation(updatedRotation);
        }
        #endregion
    }
}