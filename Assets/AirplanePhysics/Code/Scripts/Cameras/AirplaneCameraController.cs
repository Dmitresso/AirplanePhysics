using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    public class AirplaneCameraController : MonoBehaviour {
        #region Variables
        [Header("Camera Controller Properties")]
        public BaseAirplaneInput input;
        public int startCameraIndex;
        public List<Camera> cameras = new List<Camera>();

        private int cameraIndex;
        #endregion



        #region Builtin Methods
        private void Start() {
            if (startCameraIndex < 0 || startCameraIndex >= cameras.Count) return;
            DisableAllCameras();
            cameras[startCameraIndex].enabled = true;
            cameras[cameraIndex].GetComponent<AudioListener>().enabled = true;
        }

        
        private void Update() {
            if (!input) return;
            if (input.CameraSwitch) SwitchCamera();
        }
        #endregion



        #region Custom Methods
        protected virtual void SwitchCamera() {
            if (cameras.Count > 0) {
                DisableAllCameras();
                cameraIndex++;
                if (cameraIndex >= cameras.Count) cameraIndex = 0;
                cameras[cameraIndex].enabled = true;
                cameras[cameraIndex].GetComponent<AudioListener>().enabled = true;
            }
            input.CameraSwitch = false;
        }

        
        private void DisableAllCameras() {
            if (cameras.Count <= 0) return;
            foreach (var cam in cameras) {
                cam.enabled = false;
                cam.GetComponent<AudioListener>().enabled = false;
            }
        }
        #endregion
    }
}