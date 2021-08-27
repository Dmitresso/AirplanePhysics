using UnityEngine;

namespace WheelApps {
    public class BasicFollowCamera : MonoBehaviour {
        #region Variables

        #endregion


        
        #region Builtin Methods
        private void FixedUpdate() {
            HandleCamera();
        }
        #endregion
        
        

        #region Custom Methods

        protected virtual void HandleCamera() {
            
        }
        #endregion
    }
}