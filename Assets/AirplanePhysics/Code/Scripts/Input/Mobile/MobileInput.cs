using UnityEngine;


namespace WheelApps {
    public class MobileInput : BaseAirplaneInput {
        #region Variables
        [Header("Mobile IInputs Properties")]
        public MobileThumbstick lThumbstick;
        public MobileThumbstick rThumbstick;
        #endregion



        #region Custom Methods
        protected void HandleInput() {
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
        #endregion
    }
}