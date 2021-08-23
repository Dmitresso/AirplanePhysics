using UnityEngine;

namespace WheelApps {
    public class BaseAirplane_Input : MonoBehaviour {

        #region Variables
        protected float pitch;
        protected float roll;
        protected float yaw;
        protected float throttle;
        protected float brake;
        
        protected int flaps;
        public int minFlaps = 0;
        public int maxFlaps = 3;

        protected const string V = "Vertical";
        protected const string H = "Horizontal";
        protected const string Y = "Yaw";
        protected const string T = "Throttle";

        public KeyCode brakeKey = KeyCode.Space;
        public KeyCode lFlap = KeyCode.F;
        public KeyCode rFlap = KeyCode.G;
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

        private void Update() {
            HandleInput();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput() {
            pitch = Input.GetAxis(V);
            roll = Input.GetAxis(H);
            yaw = Input.GetAxis(Y);
            throttle = Input.GetAxis(T);

            brake = Input.GetKey(brakeKey) ? 1f : 0f;

            if (Input.GetKeyDown(lFlap)) flaps += 1;
            if (Input.GetKeyDown(rFlap)) flaps -= 1;
            flaps = Mathf.Clamp(flaps, minFlaps, maxFlaps);
        }
        
        #endregion
    }
}