using UnityEngine;

namespace WheelApps {
    [RequireComponent(typeof(Camera))]
    public class BasicFollowCamera : MonoBehaviour {
        #region Variables
        [Header("Basic Follow Camera Properties")]
        public Transform target;
        public float distance = 10f;
        public float height = 6f;
        public float smoothSpeed = 0.5f;

        protected float originHeight;
        
        private Vector3 smoothVelocity;
        #endregion


        
        #region Builtin Methods
        private void Start() {
            originHeight = height;
        }

        private void FixedUpdate() {
            if(target) HandleCamera();
        }
        #endregion
        
        

        #region Custom Methods

        protected virtual void HandleCamera() {
            var targetPosition = target.position + - target.forward * distance + Vector3.up * height;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothSpeed);
            
            transform.LookAt(target);
        }
        #endregion
    }
}