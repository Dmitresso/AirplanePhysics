namespace WheelApps {
    public class AirplaneCamera : BasicFollowCamera {
        #region Variables

        #endregion


        
        #region Builtin Methods
        private void FixedUpdate() {
            HandleCamera();
        }
        #endregion
        
        

        #region Custom Methods
        protected override void HandleCamera() {
            base.HandleCamera();
        }
        #endregion
    }
}