using UnityEngine;

namespace WheelApps {
    public class AirplaneAltitude : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Altitude Indicator Properties")]
        public AirplaneController airplane;
        public RectTransform bgRect;
        public RectTransform arrowRect;
        
        #endregion



        #region Interface Methods
        public void HandleAirplaneUI() {
            if (!airplane) return;
            var bankAngle = Vector3.Dot(airplane.transform.right, Vector3.up) * Mathf.Rad2Deg;
            var pitchAngle = Vector3.Dot(airplane.transform.forward, Vector3.up) * Mathf.Rad2Deg;
            if (!bgRect) return;
            var bankRot = Quaternion.Euler(0f, 0f, bankAngle);
            bgRect.transform.rotation = bankRot;

            var targetPosition = new Vector3(0f, pitchAngle, 0f);
            bgRect.anchoredPosition = targetPosition;

            if (!arrowRect) return;
            arrowRect.transform.rotation = bankRot;
        }
        #endregion

    }
}
