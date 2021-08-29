using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    public class AirplaneCameraController : MonoBehaviour {
        #region Variables
        [Header("Camera Controller Properties")]
        public BaseAirplaneInput input;
        public List<Camera> cameras = new List<Camera>();

        private int cameraIndex = 0;
        #endregion



        #region Builtin Methods

        private void Update() {
            if (!input) return;
            if (input.CameraSwitch) SwitchCamera();
        }

        #endregion



        #region Custom Methods
        protected virtual void SwitchCamera() {
            if (cameras.Count <= 0) return;
            DisableAllCameras();
            cameraIndex++;
            if (cameraIndex >= cameras.Count) cameraIndex = 0;
            cameras[cameraIndex].enabled = true;
        }

        private void DisableAllCameras() {
            if (cameras.Count <= 0) return;
            foreach (var cam in cameras) cam.enabled = false;
        }
        #endregion
    }
}