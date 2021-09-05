using UnityEngine;

namespace WheelApps {
    public class XboxAirplaneInput : BaseAirplaneInput {
        #region Variables
        #endregion
        
        
        
        #region Constants
        private const string Fire1 = "Fire1";
        private const string Y = "X_RH_Stick";
        private const string T = "X_RV_Stick";
        private const string XRB = "X_R_Bumper";
        private const string XLB = "X_L_Bumper";
        private const string XYB = "X_Y_Bumper";
        #endregion

        
        
        #region Custom Methods
        protected override void HandleInput() {
            pitch += Input.GetAxis(V);
            roll += Input.GetAxis(H);
            yaw += Input.GetAxis(Y);
            throttle += Input.GetAxis(T);

            brake = Input.GetAxis(Fire1);

            if (Input.GetKeyDown(XRB)) flaps += 1;
            if (Input.GetKeyDown(XLB)) flaps -= 1;
            flaps = Mathf.Clamp(flaps, minFlaps, maxFlaps);

            cameraSwitch = Input.GetButtonDown(XYB) || Input.GetKeyDown(cameraKey);
        }
        #endregion
    }
}