using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheel : MonoBehaviour {
        #region Variables

        [Header("Wheel Properties")]
        public Transform wheelGraphic;
        public bool isBraking;
        public float brakePower = 5f;

        private WheelCollider collider;
        private Vector3 worldPosition;
        private Quaternion worldRotation;
        private float finalBrakeForce;
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

            if (input.Brake > 0.1f) {
                finalBrakeForce = Mathf.Lerp(finalBrakeForce, input.Brake * brakePower, Time.deltaTime);
                collider.brakeTorque = finalBrakeForce;
            }
            else {
                collider.brakeTorque = 0f;
                collider.motorTorque = 0.000000001f;
            }
        }
        #endregion
    }
}