using UnityEngine;


namespace WheelApps {
    public class MobileThumbstick : MonoBehaviour {
        #region Variables
        [Header("Thumbstick Properties")]
        public bool useMouse = true;
        public RectTransform knob;

        private RectTransform bounds;
        private Vector2 finalDelta;
        private bool isTouching;
        private float knobSpeed = 10f;
        #endregion



        #region Builtin Methods

        private void Start() {
            bounds = GetComponent<RectTransform>();
        }


        private void Update() {
            if (bounds && knob) HandleThumbstick();
        }
        #endregion



        #region Custom Methods
        private void HandleThumbstick() {
            if (!isTouching)
                isTouching = RectTransformUtility.RectangleContainsScreenPoint(bounds, Input.mousePosition);
            if (useMouse) HandleMouse();
            else HandleTouches();
        }



        private void HandleMouse() {
            if (Input.GetMouseButton(0)) {
                if (isTouching) HandleDragging();
            }
            else {
                isTouching = false;
                ResetKnob();
            }
        }


        private void HandleTouches() {

        }


        private void HandleDragging() {
            var targetPosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(bounds, Input.mousePosition, null, out targetPosition);
            knob.anchoredPosition = Vector2.Lerp(knob.anchoredPosition, targetPosition, knobSpeed * Time.deltaTime);
        }


        private void ResetKnob() {
            knob.anchoredPosition = Vector2.Lerp(knob.anchoredPosition, Vector2.zero, knobSpeed * Time.deltaTime);
        }
        #endregion
    }
}