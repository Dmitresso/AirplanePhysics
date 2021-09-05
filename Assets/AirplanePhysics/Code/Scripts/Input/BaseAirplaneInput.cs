using UnityEngine;


namespace WheelApps {
    public class BaseAirplaneInput : MonoBehaviour {
        #region Variables
        protected float pitch;
        protected float roll;
        protected float yaw;
        protected float throttle;
        protected float brake;
        protected float throttleSpeed = 0.1f;
        
        protected int flaps;
        public int maxFlapIncrements = 2;
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

        public float NormalizedFlaps => (float) flaps / maxFlapIncrements;

        public float Brake => brake;
        
        public bool CameraSwitch {
            get => cameraSwitch;
            set => cameraSwitch = value;
        }

        #endregion
        
        
        
        #region Builtin Metods
        private void Update() {
            HandleInput();
            HandleStickyThrottle();
            ClampInputs();
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

            cameraSwitch = Input.GetKeyDown(cameraKey);
        }
        
        
        protected void HandleStickyThrottle() {
            stickyThrottle += - throttle * throttleSpeed * Time.deltaTime;
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }
        
        
        protected void ClampInputs() {
            pitch = Mathf.Clamp(pitch, -1f, 1f);
            roll = Mathf.Clamp(roll, -1f, 1f);
            yaw = Mathf.Clamp(yaw, -1f, 1f);
            throttle = Mathf.Clamp(throttle, -1f, 1f);
            flaps = Mathf.Clamp(flaps, minFlaps, maxFlaps);
        }
        #endregion
    }
}