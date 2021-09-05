using UnityEngine;


namespace WheelApps {
    public enum ControlSurfaceType {
        Rudder,
        Elevator,
        Flap,
        Aileron
    }
    
    
    public class AirplaneControlSurface : MonoBehaviour {
        #region Variables
        [Header("Control Surfaces Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;
        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;
        public Transform controlSurfaceGraphic;
        public float smoothSpeed;

        private float targetAngle;
        #endregion

        
        
        #region Builtin Methods
        private void Update() {
            if (!controlSurfaceGraphic) return;
            var finalAngleAxis = axis * targetAngle;
            controlSurfaceGraphic.localRotation = Quaternion.Slerp(controlSurfaceGraphic.localRotation, Quaternion.Euler(finalAngleAxis), smoothSpeed * Time.deltaTime);
        }
        #endregion
        
        

        #region Custom Methods
        public void HandleControlSurface(BaseAirplaneInput input) {
            var inputValue = type switch {
                ControlSurfaceType.Rudder => input.Yaw,
                ControlSurfaceType.Elevator => input.Pitch,
                ControlSurfaceType.Flap => input.Flaps,
                ControlSurfaceType.Aileron => input.Roll
            };
            targetAngle = maxAngle * inputValue;
        }
        #endregion
    }
}