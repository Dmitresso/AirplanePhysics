using UnityEngine;


namespace WheelApps {
    public class AirplaneGroundEffect : MonoBehaviour {
        #region Variables
        public float maxGroundDistance = 3f;
        public float liftForce = 100f;
        public float maxSpeed = 15f;
        
        private Rigidbody rb;
        #endregion
        
        
        
        #region Builtin Methods
        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        
        private void FixedUpdate() {
            if (!rb) return;
            HandleGroundEffect();
        }
        #endregion

        

        #region Custom Methods
        protected virtual void HandleGroundEffect() {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, Vector3.down, out hit)) return;
            if (hit.transform.CompareTag(Tags.Ground) && hit.distance < maxGroundDistance) {
                var currentSpeed = rb.velocity.magnitude;
                var normalizedSpeed = currentSpeed / maxSpeed;
                normalizedSpeed = Mathf.Clamp01(normalizedSpeed);
                
                var distance = maxGroundDistance - hit.distance;
                var finalForce = liftForce * distance * normalizedSpeed;
                rb.AddForce(Vector3.up * finalForce);
            }
        }
        #endregion
    }
}