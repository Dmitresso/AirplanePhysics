using System;
using UnityEngine;

namespace WheelApps {
    public class AirplanePropeller : MonoBehaviour {
        #region Variables

        [Header("Propeller Properties")]
        public float minQuadRPMs = 300f;
        public GameObject mainProp;
        public GameObject blurredProp;
        #endregion



        #region Builtin Methods

        private void Start() {
            if (mainProp && blurredProp) HandleSwapping(0f);            
        }

        #endregion



        #region Custom Methods
        public void HandlePropeller(float currentRPM) {
            // degrees per second
            var dps = currentRPM * 360f / 60f * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);

            if (mainProp && blurredProp) HandleSwapping(currentRPM);
        }

        private void HandleSwapping(float currentRPM) {
            if (currentRPM > minQuadRPMs) {
                blurredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);
            }
            else {
                blurredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }
        
        #endregion
    }
}