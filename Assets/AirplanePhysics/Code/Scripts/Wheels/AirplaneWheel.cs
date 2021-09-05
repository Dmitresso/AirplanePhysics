using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheel : MonoBehaviour {
        #region Variables
        [Header("Wheel Properties")]
        public Transform wheelGraphic;
        public bool isBraking;
        public float brakePower = 5f;
        public bool isSteering;
        public float steeringAngle = 20f;
        public float steerSmoothSpeed = 8f;
        
        private WheelCollider collider;
        private Vector3 worldPosition;
        private Quaternion worldRotation;
        private float finalBrakeForce;
        private float finalSteerAngle;
        #endregion


        
        #region Properties
        private bool isGrounded;
        public bool IsGrounded => isGrounded;
        #endregion

        

        #region Builtin Methods
        private void Start() {
            collider = GetComponent<WheelCollider>();
        }
        #endregion



        #region Custom Methods
        public void Init() {
            if (collider) collider.motorTorque = 0.000000001f;
        }

        
        public void HandleWheel(BaseAirplaneInput input) {
            if (!collider) return;
            collider.GetWorldPose(out worldPosition, out worldRotation);
            if (wheelGraphic) {
                wheelGraphic.position = worldPosition;
                wheelGraphic.rotation = worldRotation;                
            }

            if (isBraking) {
                if (input.Brake > 0.1f) {
                    finalBrakeForce = Mathf.Lerp(finalBrakeForce, input.Brake * brakePower, Time.deltaTime);
                    collider.brakeTorque = finalBrakeForce;
                }
                else {
                    finalBrakeForce = 0f;
                    collider.brakeTorque = 0f;
                    collider.motorTorque = 0.000000001f;
                }
            }

            if (isSteering) {
                finalSteerAngle = Mathf.Lerp(finalSteerAngle, - input.Yaw * steeringAngle, steerSmoothSpeed * Time.deltaTime);
                collider.steerAngle = finalSteerAngle;
            }

            isGrounded = collider.isGrounded;
        }
        #endregion
    }
}