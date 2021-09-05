using UnityEngine;


namespace WheelApps {
    public class AirplaneCamera : BasicFollowCamera {
        #region Variables
        [Header("Airplane Camera Properties")]
        public float minHeightFromGround = 6f;
        #endregion


        
        #region Builtin Methods
        private void FixedUpdate() {
            HandleCamera();
        }
        #endregion
        
        

        #region Custom Methods
        protected override void HandleCamera() {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
                if (hit.distance < minHeightFromGround && hit.transform.CompareTag(Tags.Ground)) {
                    var targetHeight = originHeight + minHeightFromGround - hit.distance;
                    height = targetHeight;
                }
            }
            
            base.HandleCamera();
        }
        #endregion
    }
}