using UnityEngine;


namespace WheelApps {
    public class AirplaneFlapLever : MonoBehaviour, IAirplaneUI {
        #region Variables
        [Header("Flap Lever Properties")]
        public BaseAirplaneInput input;
        public RectTransform parentRect;
        public RectTransform handleRect;
        public float handleSpeed = 2f;
        #endregion


        #region Interface Methods
        public void HandleAirplaneUI() {
            if (!input || !parentRect || !handleRect) return;
            var height = parentRect.rect.height;
            var targetHandlePosition = new Vector2(0f, - height * input.NormalizedFlaps);
            handleRect.anchoredPosition = Vector2.Lerp(handleRect.anchoredPosition, targetHandlePosition, handleSpeed * Time.deltaTime);
        }
        #endregion
    }
}