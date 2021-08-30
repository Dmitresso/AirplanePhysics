using UnityEngine;


namespace WheelApps {
    public class AirplaneThrottleLever : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Throttle Lever Properties")]
        public BaseAirplaneInput input;
        public RectTransform parentRect;
        public RectTransform handleRect;
        public float handleSpeed = 2f;
        #endregion



        #region Interface Metods
        public void HandleAirplaneUI() {
            if (!input || !parentRect || !handleRect) return;
            var height = parentRect.rect.height;
            var targetHandlePosition = new Vector2(0f, height * input.StickyThrottle);
            handleRect.anchoredPosition = Vector2.Lerp(handleRect.anchoredPosition, targetHandlePosition, handleSpeed * Time.deltaTime);

        }
        #endregion
    }
}