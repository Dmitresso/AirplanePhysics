using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheel : MonoBehaviour {
        #region Variables

        [Header("Wheel Properties")]
        public Transform wheelGraphic;
        
        private WheelCollider collider;
        private Vector3 worldPosition;
        private Quaternion worldRotation;
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
            if (!wheelGraphic) return;
            wheelGraphic.position = worldPosition;
            wheelGraphic.rotation = worldRotation;
        }
        #endregion
    }
}