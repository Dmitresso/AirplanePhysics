using UnityEngine;


namespace WheelApps {
    public class AirplaneAltimeter : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Altimeter Properties")]
        public AirplaneController airplane;

        public RectTransform hundredsPointer;
        public RectTransform thousandsPointer;
        #endregion



        #region Interface Methods
        public void HandleAirplaneUI() {
            if (!airplane) return;
            var currentAltitude = airplane.CurrentMSL;
            var currentThousands = currentAltitude * 0.001f;
            currentThousands = Mathf.Clamp(currentThousands, 0f, 10f);

            var currentHundreds = currentAltitude - Mathf.Floor(currentThousands) * 1000f;
            currentHundreds = Mathf.Clamp(currentHundreds, 0f, 1000f);
            
            if (thousandsPointer) {
                var normalizedThousands = Mathf.InverseLerp(0f, 10f, currentThousands);
                var thousandsRotation = normalizedThousands * 360f;
                thousandsPointer.rotation = Quaternion.Euler(0f, 0f, - thousandsRotation);                
            }

            if (hundredsPointer) {
                var normalizedHundreds = Mathf.InverseLerp(0f, 1000f, currentHundreds);
                var hundredsRotation = normalizedHundreds * 360f;
                hundredsPointer.rotation = Quaternion.Euler(0f, 0f, - hundredsRotation);
            }
        }
        #endregion
    }
}