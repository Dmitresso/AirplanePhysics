using UnityEngine;

namespace WheelApps {
    public class AirplaneGroundEffect : MonoBehaviour {
        #region Variables
        public float maxGroundDistance = 3f;
        
        
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
                    
            }
        }
        #endregion
    }
}