using UnityEngine;

namespace WheelApps {
    public class BaseAirplane_Input : MonoBehaviour {

        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;
        protected int flaps = 0;
        protected float brake = 0f;

        private const string V = "Vertical";
        private const string H = "Horizontal";
        #endregion

        #region Properties
        public float Pitch => pitch;

        public float Roll => roll;

        public float Yaw => yaw;

        public float Throttle => throttle;

        public int Flaps => flaps;

        public float Brake => brake;
        #endregion
        
        
        #region Builtin Metods
        private void Start() { }

        private void Update() { }
        #endregion

        #region Custom Methods
        private void HandleInput() {
            pitch = Input.GetAxis(V);
            roll = Input.GetAxis(H);
        }
        

        #endregion
    }
}