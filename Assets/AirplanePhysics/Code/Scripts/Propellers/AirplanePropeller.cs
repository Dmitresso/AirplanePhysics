using UnityEngine;

namespace WheelApps {
    public class AirplanePropeller : MonoBehaviour {
        #region Variables
        #endregion



        #region Builtin Methods
        #endregion



        #region Custom Methods
        public void HandlePropeller(float currentRPM) {
            // degrees per second
            var dps = currentRPM * 360f / 60f * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);
        }
        #endregion
    }
}