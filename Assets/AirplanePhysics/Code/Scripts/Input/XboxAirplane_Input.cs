using UnityEngine;

namespace WheelApps {
    public class XboxAirplane_Input : BaseAirplane_Input {
        private const string Fire1 = "Fire1";
        
        protected override void HandleInput() {
            pitch = Input.GetAxis(V);
            roll = Input.GetAxis(H);
            yaw = Input.GetAxis(Y);
            throttle = Input.GetAxis(T);

            brake = Input.GetAxis(Fire1);

            if (Input.GetKeyDown(lFlap)) flaps += 1;
            if (Input.GetKeyDown(rFlap)) flaps -= 1;
            flaps = Mathf.Clamp(flaps, minFlaps, maxFlaps);
        }
    }
}