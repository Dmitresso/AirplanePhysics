using UnityEngine;

namespace WheelApps {
    public class BaseAirplaneInput : MonoBehaviour {
        #region Variables
        protected float pitch;
        protected float roll;
        protected float yaw;
        protected float throttle;
        protected float brake;
        
        protected int flaps;
        public int minFlaps;
        public int maxFlaps = 3;
        
        protected float stickyThrottle;
        public float StickyThrottle => stickyThrottle;

        [SerializeField] protected KeyCode cameraKey = KeyCode.C;
        [SerializeField] private KeyCode brakeKey = KeyCode.Space;
        [SerializeField] private KeyCode lFlap = KeyCode.F;
        [SerializeField] private KeyCode rFlap = KeyCode.G;

        protected bool cameraSwitch;
        #endregion

        

        #region Constants
        protected const string V = "Vertical";
        protected const string H = "Horizontal";
        private const string Y = "Yaw";
        private const string T = "Throttle";
        #endregion
        
        

        #region Properties
        public float Pitch => pitch;

        public float Roll => roll;

        public float Yaw => yaw;

        public float Throttle => throttle;

        public int Flaps => flaps;

        public float Brake => brake;
        
        public bool CameraSwitch => cameraSwitch;
        #endregion
        
        
        #region Builtin Metods
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

            cameraSwitch = Input.GetKeyDown(cameraKey);
        }
        #endregion
    }
}