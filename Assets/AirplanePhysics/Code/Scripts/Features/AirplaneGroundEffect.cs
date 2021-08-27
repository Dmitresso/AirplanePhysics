using UnityEngine;

namespace WheelApps {
    public class AirplaneGroundEffect : MonoBehaviour {
        #region Variables
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
            
        }


        #endregion
    }
}