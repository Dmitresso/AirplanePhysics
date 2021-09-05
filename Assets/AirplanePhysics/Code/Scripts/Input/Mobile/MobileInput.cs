using UnityEngine;


namespace WheelApps {
    public class MobileInput : BaseAirplaneInput {
        #region Variables
        [Header("Mobile Inputs Properties")]
        public MobileThumbstick lThumbstick;
        public MobileThumbstick rThumbstick;
        #endregion



        #region Custom Methods
        protected override void HandleInput() {
            if (!lThumbstick || !rThumbstick) return;
            pitch = lThumbstick.VerticalAxis;
            roll = lThumbstick.HorizontalAxis;
            yaw = rThumbstick.HorizontalAxis;
            throttle = - rThumbstick.VerticalAxis;
        }


        public void SetBrake(float value) {
            brake = value;
        }


        public void SetFlaps(int value) {
            flaps += value;
        }


        public void SetCamera(bool flag) {
            cameraSwitch = true;
        }
        #endregion
    }
}